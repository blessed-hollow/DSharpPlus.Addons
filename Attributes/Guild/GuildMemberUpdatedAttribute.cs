namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class GuildMemberUpdatedAttribute : Attribute
{
    public ulong MemberId { get; }

    public GuildMemberUpdatedAttribute(ulong id) => MemberId = id;

    public GuildMemberUpdatedAttribute() { }
}
