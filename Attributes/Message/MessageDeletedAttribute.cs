namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class MessageDeletedAttribute : Attribute
{
    public ulong ChannelId { get; }

    public MessageDeletedAttribute(ulong id) => ChannelId = id;

    public MessageDeletedAttribute() { }
}