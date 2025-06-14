using System.Threading.Channels;

namespace BlessedHollow.DSharpPlus.Addons.Common;
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class MessageAcknowledgedAttribute : Attribute
{
    public ulong ChannelId { get; }

    public MessageAcknowledgedAttribute(ulong id) => ChannelId = id;

    public MessageAcknowledgedAttribute() { }
}