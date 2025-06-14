namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class GuildMemberRemovedAttribute : Attribute
{
    public ulong MemberId { get; }

    public GuildMemberRemovedAttribute(ulong id) => MemberId = id;

    public GuildMemberRemovedAttribute() { }
}
