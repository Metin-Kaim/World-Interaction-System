using Assets.WorldInteractionSystem.Scripts.Abstracts;
using Assets.WorldInteractionSystem.Scripts.Datas.Interactions;
using Assets.WorldInteractionSystem.Scripts.Enums;
using System.Collections;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Entities
{
    public class ChessHandler : MonoBehaviour, IInteractable
    {
        private bool isOpened;

        public bool CanInteract => !isOpened;

        public InteractionCapabilities Capabilities => InteractionCapabilities.Hold;

        public InteractionUIData GetUIData()
        {
            return new InteractionUIData
            {
                Text = "Hold E Open",
                ShowProgress = true
            };
        }

        public void Interact(InteractionResult result)
        {
            if (isOpened) return;

            isOpened = true;
            Debug.Log("Chest opened");
        }
    }
}