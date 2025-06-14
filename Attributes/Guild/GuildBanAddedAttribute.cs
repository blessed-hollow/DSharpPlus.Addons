namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class GuildBanAddedAttribute : Attribute
{
    public ulong MemberId { get; }

    public GuildBanAddedAttribute(ulong id) => MemberId = id;

    public GuildBanAddedAttribute() { }
}
