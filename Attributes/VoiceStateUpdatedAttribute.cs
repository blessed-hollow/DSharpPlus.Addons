namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class VoiceStateUpdatedAttribute : Attribute
{
    public ulong ChannelId { get; }
    public VoiceStateUpdatedAttribute(ulong id) => ChannelId = id;
    public VoiceStateUpdatedAttribute() { }
}
