namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class GuildRoleDeletedAttribute : Attribute
{
    public ulong RoleId { get; }

    public GuildRoleDeletedAttribute(ulong id) => RoleId = id;

    public GuildRoleDeletedAttribute() { }
}
