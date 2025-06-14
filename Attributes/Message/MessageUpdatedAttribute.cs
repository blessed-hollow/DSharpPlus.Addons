namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class MessageUpdatedAttribute : Attribute
{
    public ulong ChannelId { get; }

    public MessageUpdatedAttribute(ulong id) => ChannelId = id;

    public MessageUpdatedAttribute() { }
}