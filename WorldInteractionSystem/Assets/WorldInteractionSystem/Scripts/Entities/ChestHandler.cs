using Assets.WorldInteractionSystem.Scripts.Abstracts;
using Assets.WorldInteractionSystem.Scripts.Datas.DataValues;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Entities
{
    public class ChestHandler : BaseInteractable
    {
        private bool isOpened;

        public override bool CanInteract => !isOpened;

        public override void Interact(InteractionResult result)
        {
            if (isOpened) return;

            isOpened = true;
            Debug.Log("Chest opened");
        }
    }
}