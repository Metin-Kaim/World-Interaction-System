using Assets.WorldInteractionSystem.Scripts.Abstracts;
using Assets.WorldInteractionSystem.Scripts.Datas.Interactions;
using Assets.WorldInteractionSystem.Scripts.Enums;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Entities
{
    public class DoorHandler : MonoBehaviour, IInteractable
    {
        public InteractionCapabilities Capabilities =>
            InteractionCapabilities.Hold;

        public bool CanInteract => true;

        public InteractionUIData GetUIData()
        {
            return new InteractionUIData
            {
                Text = "E Open",
                ShowProgress = true
            };
        }

        public void Interact(InteractionResult result)
        {
            Debug.Log("Door Opened");
        }
    }
}