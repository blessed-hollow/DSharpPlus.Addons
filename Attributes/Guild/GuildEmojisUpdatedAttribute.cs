namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class GuildEmojisUpdatedAttribute : Attribute
{
    public ulong GuildId { get; }

    public GuildEmojisUpdatedAttribute(ulong id) => GuildId = id;

    public GuildEmojisUpdatedAttribute() { }
}
