namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class MessageReactionAddedAttribute : Attribute
{
    public ulong ChannelId { get; }

    public MessageReactionAddedAttribute(ulong id) => ChannelId = id;

    public MessageReactionAddedAttribute() { }
}