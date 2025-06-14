namespace BlessedHollow.DSharpPlus.Addons.Common;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class ChannelDeletedAttribute : Attribute
{
    public ulong ChannelId { get; }

    public ChannelDeletedAttribute(ulong id) => ChannelId = id;

    public ChannelDeletedAttribute() { }
}
