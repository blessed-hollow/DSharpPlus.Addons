namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class ChannelPinsUpdatedAttribute : Attribute
{
    public ulong ChannelId { get; }

    public ChannelPinsUpdatedAttribute(ulong id) => ChannelId = id;

    public ChannelPinsUpdatedAttribute() { }
}
