namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class MessageReactionsClearedAttribute : Attribute
{
    public ulong ChannelId { get; }

    public MessageReactionsClearedAttribute(ulong id) => ChannelId = id;

    public MessageReactionsClearedAttribute() { }
}