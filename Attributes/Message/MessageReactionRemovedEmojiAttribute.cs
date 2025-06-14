namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class MessageReactionRemovedEmojiAttribute : Attribute
{
    public ulong ChannelId { get; }

    public MessageReactionRemovedEmojiAttribute(ulong id) => ChannelId = id;

    public MessageReactionRemovedEmojiAttribute() { }
}