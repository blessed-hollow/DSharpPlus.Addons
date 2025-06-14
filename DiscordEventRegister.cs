using BlessedHollow.DSharpPlus.Addons.Common;
using DSharpPlus;
using DSharpPlus.AsyncEvents;
using DSharpPlus.EventArgs;

namespace BlessedHollow.DSharpPlus.Addons;

internal class DiscordEventsRegister
{
    private readonly AttributeService _attributeService;
    private readonly IServiceProvider _services;
    private readonly DiscordClient _discordClient;
    private readonly List<HandlerInfo> _handlers;

    public DiscordEventsRegister(
        AttributeService attributeService,
        IServiceProvider services,
        DiscordClient discordClient)
    {
        _attributeService = attributeService;
        _services = services;
        _discordClient = discordClient;
        _handlers = new List<HandlerInfo>();
    }

    public void RegisterAllEvents()
    {
        RegisterComponentEvents();
        RegisterMessageEvents();
        RegisterChannelEvents();
        RegisterGuildEvents();
        RegisterVoiceAndInteractionEvents();
    }

    #region Component Events
    private void RegisterComponentEvents()
    {
        RegisterComponentInteractionEvent();
        RegisterModalSubmittedEvent();
    }

    private void RegisterComponentInteractionEvent()
    {
        RegisterEvent<DiscordClient, ComponentInteractionCreateEventArgs, ComponentInteractionAttribute>(
            h => _discordClient.ComponentInteractionCreated += h,
            (attr, args) => attr.CustomId == args.Id);
    }

    private void RegisterModalSubmittedEvent()
    {
        RegisterEvent<DiscordClient, ModalSubmitEventArgs, ModalInteractionAttribute>(
            h => _discordClient.ModalSubmitted += h,
            (attr, args) => attr.CustomId == args.Interaction.Data.CustomId);
    }
    #endregion

    #region Message Events
    private void RegisterMessageEvents()
    {
        RegisterMessageCreatedEvent();
        RegisterMessageDeletedEvent();
        RegisterMessageUpdatedEvent();
        RegisterMessageReactionAddedEvent();
        RegisterMessageReactionRemovedEvent();
        RegisterMessageAcknowledgedEvent();
        RegisterMessageReactionRemovedEmojiEvent();
        RegisterMessageReactionsClearedEvent();
        RegisterMessagesBulkDeletedEvent();
    }

    private void RegisterMessageCreatedEvent()
    {
        RegisterEvent<DiscordClient, MessageCreateEventArgs, MessageCreatedAttribute>(
            h => _discordClient.MessageCreated += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.Channel.Id);
    }

    private void RegisterMessageDeletedEvent()
    {
        RegisterEvent<DiscordClient, MessageDeleteEventArgs, MessageDeletedAttribute>(
            h => _discordClient.MessageDeleted += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.Channel.Id);
    }

    private void RegisterMessageUpdatedEvent()
    {
        RegisterEvent<DiscordClient, MessageUpdateEventArgs, MessageUpdatedAttribute>(
            h => _discordClient.MessageUpdated += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.Channel.Id);
    }

    private void RegisterMessageReactionAddedEvent()
    {
        RegisterEvent<DiscordClient, MessageReactionAddEventArgs, MessageReactionAddedAttribute>(
            h => _discordClient.MessageReactionAdded += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.Channel.Id);
    }

    private void RegisterMessageReactionRemovedEvent()
    {
        RegisterEvent<DiscordClient, MessageReactionRemoveEventArgs, MessageReactionRemovedAttribute>(
            h => _discordClient.MessageReactionRemoved += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.Channel.Id);
    }

    private void RegisterMessageAcknowledgedEvent()
    {
        RegisterEvent<DiscordClient, MessageAcknowledgeEventArgs, MessageAcknowledgedAttribute>(
            h => _discordClient.MessageAcknowledged += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.Channel.Id);
    }

    private void RegisterMessageReactionRemovedEmojiEvent()
    {
        RegisterEvent<DiscordClient, MessageReactionRemoveEmojiEventArgs, MessageReactionRemovedEmojiAttribute>(
            h => _discordClient.MessageReactionRemovedEmoji += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.Channel.Id);
    }

    private void RegisterMessageReactionsClearedEvent()
    {
        RegisterEvent<DiscordClient, MessageReactionsClearEventArgs, MessageReactionsClearedAttribute>(
            h => _discordClient.MessageReactionsCleared += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.Channel.Id);
    }

    private void RegisterMessagesBulkDeletedEvent()
    {
        RegisterEvent<DiscordClient, MessageBulkDeleteEventArgs, MessagesBulkDeletedAttribute>(
            h => _discordClient.MessagesBulkDeleted += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.Channel.Id);
    }
    #endregion

    #region Channel Events
    private void RegisterChannelEvents()
    {
        RegisterChannelCreatedEvent();
        RegisterChannelDeletedEvent();
        RegisterChannelUpdatedEvent();
        RegisterChannelPinsUpdatedEvent();
        RegisterDmChannelDeletedEvent();
    }

    private void RegisterChannelCreatedEvent()
    {
        RegisterEvent<DiscordClient, ChannelCreateEventArgs, ChannelCreatedAttribute>(
            h => _discordClient.ChannelCreated += h);
    }

    private void RegisterChannelDeletedEvent()
    {
        RegisterEvent<DiscordClient, ChannelDeleteEventArgs, ChannelDeletedAttribute>(
            h => _discordClient.ChannelDeleted += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.Channel.Id);
    }

    private void RegisterChannelUpdatedEvent()
    {
        RegisterEvent<DiscordClient, ChannelUpdateEventArgs, ChannelUpdatedAttribute>(
            h => _discordClient.ChannelUpdated += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.ChannelAfter.Id);
    }

    private void RegisterChannelPinsUpdatedEvent()
    {
        RegisterEvent<DiscordClient, ChannelPinsUpdateEventArgs, ChannelPinsUpdatedAttribute>(
            h => _discordClient.ChannelPinsUpdated += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.Channel.Id);
    }

    private void RegisterDmChannelDeletedEvent()
    {
        RegisterEvent<DiscordClient, DmChannelDeleteEventArgs, DmChannelDeletedAttribute>(
            h => _discordClient.DmChannelDeleted += h);
    }
    #endregion

    #region Guild Events
    private void RegisterGuildEvents()
    {
        RegisterGuildBanAddedEvent();
        RegisterGuildBanRemovedEvent();
        RegisterGuildCreatedEvent();
        RegisterGuildDeletedEvent();
        RegisterGuildUpdatedEvent();
        RegisterGuildEmojisUpdatedEvent();
        RegisterGuildMemberAddedEvent();
        RegisterGuildMemberRemovedEvent();
        RegisterGuildMemberUpdatedEvent();
        RegisterGuildRoleCreatedEvent();
        RegisterGuildRoleDeletedEvent();
        RegisterGuildRoleUpdatedEvent();
        RegisterGuildStickersUpdatedEvent();
    }

    private void RegisterGuildBanAddedEvent()
    {
        RegisterEvent<DiscordClient, GuildBanAddEventArgs, GuildBanAddedAttribute>(
            h => _discordClient.GuildBanAdded += h,
            (attr, args) => attr.MemberId == 0 || attr.MemberId == args.Member.Id);
    }

    private void RegisterGuildBanRemovedEvent()
    {
        RegisterEvent<DiscordClient, GuildBanRemoveEventArgs, GuildBanRemovedAttribute>(
            h => _discordClient.GuildBanRemoved += h,
            (attr, args) => attr.MemberId == 0 || attr.MemberId == args.Member.Id);
    }

    private void RegisterGuildCreatedEvent()
    {
        RegisterEvent<DiscordClient, GuildCreateEventArgs, GuildCreatedAttribute>(
            h => _discordClient.GuildCreated += h);
    }

    private void RegisterGuildDeletedEvent()
    {
        RegisterEvent<DiscordClient, GuildDeleteEventArgs, GuildDeletedAttribute>(
            h => _discordClient.GuildDeleted += h,
            (attr, args) => attr.GuildId == 0 || attr.GuildId == args.Guild.Id);
    }

    private void RegisterGuildUpdatedEvent()
    {
        RegisterEvent<DiscordClient, GuildUpdateEventArgs, GuildUpdatedAttribute>(
            h => _discordClient.GuildUpdated += h,
            (attr, args) => attr.GuildId == 0 || attr.GuildId == args.GuildAfter.Id);
    }

    private void RegisterGuildEmojisUpdatedEvent()
    {
        RegisterEvent<DiscordClient, GuildEmojisUpdateEventArgs, GuildEmojisUpdatedAttribute>(
            h => _discordClient.GuildEmojisUpdated += h,
            (attr, args) => attr.GuildId == 0 || attr.GuildId == args.Guild.Id);
    }

    private void RegisterGuildMemberAddedEvent()
    {
        RegisterEvent<DiscordClient, GuildMemberAddEventArgs, GuildMemberAddedAttribute>(
            h => _discordClient.GuildMemberAdded += h,
            (attr, args) => attr.MemberId == 0 || attr.MemberId == args.Member.Id);
    }

    private void RegisterGuildMemberRemovedEvent()
    {
        RegisterEvent<DiscordClient, GuildMemberRemoveEventArgs, GuildMemberRemovedAttribute>(
            h => _discordClient.GuildMemberRemoved += h,
            (attr, args) => attr.MemberId == 0 || attr.MemberId == args.Member.Id);
    }

    private void RegisterGuildMemberUpdatedEvent()
    {
        RegisterEvent<DiscordClient, GuildMemberUpdateEventArgs, GuildMemberUpdatedAttribute>(
            h => _discordClient.GuildMemberUpdated += h,
            (attr, args) => attr.MemberId == 0 || attr.MemberId == args.Member.Id);
    }

    private void RegisterGuildRoleCreatedEvent()
    {
        RegisterEvent<DiscordClient, GuildRoleCreateEventArgs, GuildRoleCreatedAttribute>(
            h => _discordClient.GuildRoleCreated += h);
    }

    private void RegisterGuildRoleDeletedEvent()
    {
        RegisterEvent<DiscordClient, GuildRoleDeleteEventArgs, GuildRoleDeletedAttribute>(
            h => _discordClient.GuildRoleDeleted += h,
            (attr, args) => attr.RoleId == 0 || attr.RoleId == args.Role.Id);
    }

    private void RegisterGuildRoleUpdatedEvent()
    {
        RegisterEvent<DiscordClient, GuildRoleUpdateEventArgs, GuildRoleUpdatedAttribute>(
            h => _discordClient.GuildRoleUpdated += h,
            (attr, args) => attr.RoleId == 0 || attr.RoleId == args.RoleAfter.Id);
    }

    private void RegisterGuildStickersUpdatedEvent()
    {
        RegisterEvent<DiscordClient, GuildStickersUpdateEventArgs, GuildStickersUpdatedAttribute>(
            h => _discordClient.GuildStickersUpdated += h,
            (attr, args) => attr.GuildId == 0 || attr.GuildId == args.Guild.Id);
    }
    #endregion

    #region Voice and Interaction Events
    private void RegisterVoiceAndInteractionEvents()
    {
        RegisterVoiceStateUpdatedUpdatedEvent();
        RegisterInteractionCreatedEvent();
    }

    private void RegisterVoiceStateUpdatedUpdatedEvent()
    {
        RegisterEvent<DiscordClient, VoiceStateUpdateEventArgs, VoiceStateUpdatedAttribute>(
            h => _discordClient.VoiceStateUpdated += h,
            (attr, args) => attr.ChannelId == 0 || attr.ChannelId == args.Channel?.Id);
    }

    private void RegisterInteractionCreatedEvent()
    {
        RegisterEvent<DiscordClient, InteractionCreateEventArgs, InteractionAttribute>(
            h => _discordClient.InteractionCreated += h);
    }
    #endregion

    private void RegisterEvent<TSender, TArgs, TAttr>(
        Action<AsyncEventHandler<DiscordClient, TArgs>> subscribe,
        Func<TAttr, TArgs, bool>? filter = null)
        where TArgs : DiscordEventArgs
        where TAttr : Attribute
    {
        var handlers = _attributeService.GetEventHandlers<TArgs, TAttr>(_services);
        if (handlers == null || !handlers.Any())
            return;

        _handlers.AddRange(handlers);

        subscribe(async (sender, args) =>
        {
            foreach (var handler in handlers)
            {
                var attr = (TAttr)handler.Attribute;
                if (filter == null || filter(attr, args))
                    await handler.Delegate.Invoke(sender, args);
            }
        });
    }
}