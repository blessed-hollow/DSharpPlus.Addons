namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class GuildStickersUpdatedAttribute : Attribute
{
    public ulong GuildId { get; }

    public GuildStickersUpdatedAttribute(ulong id) => GuildId = id;

    public GuildStickersUpdatedAttribute() { }
}
