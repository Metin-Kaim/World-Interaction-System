using Assets.WorldInteractionSystem.Scripts.Datas.DataValues;
using Assets.WorldInteractionSystem.Scripts.Enums;

namespace Assets.WorldInteractionSystem.Scripts.Abstracts
{
    public interface IInteractable
    {
        bool CanInteract { get; }

        InteractionCapabilities Capabilities { get; }

        InteractionUIData GetUIData();

        void Interact(InteractionResult result);
    }

}
