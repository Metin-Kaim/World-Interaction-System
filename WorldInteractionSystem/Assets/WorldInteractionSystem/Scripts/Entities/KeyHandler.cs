using Assets.WorldInteractionSystem.Scripts.Abstracts;
using Assets.WorldInteractionSystem.Scripts.Datas.Interactions;
using Assets.WorldInteractionSystem.Scripts.Enums;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Entities
{
    public class KeyHandler : MonoBehaviour, IInteractable
    {
        public InteractionCapabilities Capabilities =>
            InteractionCapabilities.Press;

        public bool CanInteract => true;

        public InteractionUIData GetUIData()
        {
            return new InteractionUIData
            {
                Text = "E Pick Up",
                ShowProgress = false
            };
        }

        public void Interact(InteractionResult result)
        {
            Debug.Log("Key picked up");
        }
    }
}