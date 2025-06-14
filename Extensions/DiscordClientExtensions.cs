using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;
using System.Reflection;

namespace BlessedHollow.DSharpPlus.Addons;

public static class DiscordClientExtensions
{

    private static bool isRegistered = false;
    public static void RegisterHandlers(this DiscordClient client, IServiceProvider services = null)
    {
        if (isRegistered)
        {
            return;
        }

        AttributeService attributeService = new();
        var register = new DiscordEventsRegister(attributeService, services, client);
        register.RegisterAllEvents();

        isRegistered = true;
    }

    public static CommandsNextExtension RegisterCommandsNextFromCurrentAssembly(
        this DiscordClient client,
        IServiceProvider services = null)
    {
        var config = new CommandsNextConfiguration
        {
            Services = services
        };

        var commandsNext = client.GetCommandsNext()
            ?? client.UseCommandsNext(config);

        var commandTypes = Assembly.GetCallingAssembly()
            .GetTypes()
            .Where(t => t.IsClass &&
            !t.IsAbstract &&
                       t.IsSubclassOf(typeof(BaseCommandModule)));

        foreach (var type in commandTypes)
        {
            commandsNext.RegisterCommands(type);
        }

        return commandsNext;
    }

    public static SlashCommandsExtension RegisterSlashCommandsFromCurrentAssembly(
        this DiscordClient client,
        IServiceProvider services = null)
    {
        var slashCommands = client.GetSlashCommands()
            ?? client.UseSlashCommands(new SlashCommandsConfiguration
            {
                Services = services
            });

        var commandTypes = Assembly.GetCallingAssembly()
            .GetTypes()
            .Where(t => t.IsClass &&
                       !t.IsAbstract &&
                       t.IsSubclassOf(typeof(ApplicationCommandModule)));

        foreach (var type in commandTypes)
        {
            slashCommands.RegisterCommands(type);
        }
        return slashCommands;
    }
}
