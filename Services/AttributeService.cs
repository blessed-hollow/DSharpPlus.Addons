using DSharpPlus;
using DSharpPlus.AsyncEvents;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BlessedHollow.DSharpPlus.Addons;


public record HandlerInfo(Attribute Attribute, AsyncEventHandler<DiscordClient, DiscordEventArgs> Delegate);

internal class AttributeService
{
    public IEnumerable<HandlerInfo> GetEventHandlers
        <TEvent, TAttribute>(IServiceProvider services)
        where TAttribute : Attribute
        where TEvent : DiscordEventArgs
    {
        var methods = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .SelectMany(type => type.GetMethods(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Instance))
            .Where(x => x
            .GetCustomAttributes(typeof(TAttribute), false).Length != 0 &&
            x.GetParameters().Length == 2 &&
            x.GetParameters()[0].ParameterType == typeof(DiscordClient) &&
            x.GetParameters()[1].ParameterType == typeof(TEvent) &&
            IsAsyncMethod(x) &&
            x.ReturnType == typeof(Task));

        var list = new List<HandlerInfo>();

        foreach (var method in methods)
        {
            var attributes = method.GetCustomAttributes<TAttribute>();

            foreach (var attribute in attributes!)
            {
                var eventHandler = method.CreateDelegate(typeof(AsyncEventHandler<DiscordClient, TEvent>),
                                ActivatorUtilities.CreateInstance(services, method.DeclaringType!))
                                as AsyncEventHandler<DiscordClient, TEvent>;

                var convertedHandler = ConvertHandler(
                    eventHandler!);

                if (convertedHandler != null && attribute != null)
                {
                    list.Add(new HandlerInfo(attribute, convertedHandler));
                }
            }
        }
        return list;
    }
    private bool IsAsyncMethod(MethodInfo methodInfo)
    {
        MethodInfo method = methodInfo.ReflectedType.GetMethod(methodInfo.Name);
        Type attType = typeof(AsyncStateMachineAttribute);
        var attrib = method.GetCustomAttribute(attType) as AsyncStateMachineAttribute;
        return attrib != null;
    }

    private AsyncEventHandler<DiscordClient, DiscordEventArgs> ConvertHandler<TEvent>(
    AsyncEventHandler<DiscordClient, TEvent> specificHandler)
    where TEvent : DiscordEventArgs
    {
        return async (client, args) =>
        {
            if (args is TEvent specificArgs)
            {
                await specificHandler(client, specificArgs);
            }
        };
    }
}
