namespace BlessedHollow.DSharpPlus.Addons.Common;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class ChannelUpdatedAttribute : Attribute
{
    public ulong ChannelId { get; }

    public ChannelUpdatedAttribute(ulong id) => ChannelId = id;

    public ChannelUpdatedAttribute() { }
}
