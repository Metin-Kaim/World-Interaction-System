using System;

namespace Assets.WorldInteractionSystem.Scripts.Enums
{
    [Flags]
    public enum InteractionCapabilities
    {
        None = 0,
        Press = 1,
        Hold = 2
    }
}
