namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class MessagesBulkDeletedAttribute : Attribute
{
    public ulong ChannelId { get; }

    public MessagesBulkDeletedAttribute(ulong id) => ChannelId = id;

    public MessagesBulkDeletedAttribute() { }
}