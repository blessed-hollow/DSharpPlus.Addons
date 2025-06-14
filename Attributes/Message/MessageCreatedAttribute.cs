namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class MessageCreatedAttribute : Attribute
{
    public ulong ChannelId { get; }

    public MessageCreatedAttribute(ulong id) => ChannelId = id;

    public MessageCreatedAttribute() { }
}