namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class GuildUpdatedAttribute : Attribute
{
    public ulong GuildId { get; }

    public GuildUpdatedAttribute(ulong id) => GuildId = id;

    public GuildUpdatedAttribute() { }
}