using DSharpPlus.EventArgs;

namespace BlessedHollow.DSharpPlus.Addons;

public enum VoiceActionType
{
    Join,
    Leave,
    Move,
    None
}

public static class VoiceState
{
    public static VoiceActionType GetUserActionType(VoiceStateUpdateEventArgs voiceArgs)
    {

        if (voiceArgs.Before?.Channel != null && voiceArgs.After?.Channel != null && voiceArgs.Before?.Channel
            != voiceArgs.After?.Channel)
            return VoiceActionType.Move;
        if (voiceArgs.Before?.Channel != null && voiceArgs.After?.Channel == null)
            return VoiceActionType.Leave;
        if (voiceArgs.Before?.Channel == null && voiceArgs.After?.Channel != null)
            return VoiceActionType.Join;

        return VoiceActionType.None;
    }
}
