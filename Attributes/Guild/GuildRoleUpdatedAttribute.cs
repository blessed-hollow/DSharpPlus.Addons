namespace BlessedHollow.DSharpPlus.Addons.Common;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class GuildRoleUpdatedAttribute : Attribute
{
    public ulong RoleId { get; }

    public GuildRoleUpdatedAttribute(ulong id) => RoleId = id;

    public GuildRoleUpdatedAttribute() { }
}
