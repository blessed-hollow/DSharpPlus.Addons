namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class ModalInteractionAttribute : Attribute
{
    public string CustomId { get; }
    public ModalInteractionAttribute(string name) => CustomId = name;
}
