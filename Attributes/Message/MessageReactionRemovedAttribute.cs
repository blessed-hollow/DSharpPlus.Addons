namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class MessageReactionRemovedAttribute : Attribute
{
    public ulong ChannelId { get; }

    public MessageReactionRemovedAttribute(ulong id) => ChannelId = id;

    public MessageReactionRemovedAttribute() { }
}