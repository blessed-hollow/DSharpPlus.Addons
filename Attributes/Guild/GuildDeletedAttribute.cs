namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class GuildDeletedAttribute : Attribute
{
    public ulong GuildId { get; }

    public GuildDeletedAttribute(ulong id) => GuildId = id;

    public GuildDeletedAttribute() { }
}