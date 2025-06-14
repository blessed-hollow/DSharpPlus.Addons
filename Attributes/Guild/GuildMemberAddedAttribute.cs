namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class GuildMemberAddedAttribute : Attribute 
{
    public ulong MemberId { get; }

    public GuildMemberAddedAttribute(ulong id) => MemberId = id;

    public GuildMemberAddedAttribute() { }
}
