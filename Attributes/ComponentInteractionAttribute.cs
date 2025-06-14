namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class ComponentInteractionAttribute : Attribute
{
    public string CustomId { get; }
    public ComponentInteractionAttribute(string name) => CustomId = name;
}
