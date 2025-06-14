namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class GuildBanRemovedAttribute : Attribute
{
    public ulong MemberId { get; }

    public GuildBanRemovedAttribute(ulong id) => MemberId = id;

    public GuildBanRemovedAttribute() { }
}
