using Assets.WorldInteractionSystem.Scripts.Abstracts;
using Assets.WorldInteractionSystem.Scripts.Datas.DataValues;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Entities
{
    public class DoorHandler : BaseInteractable
    {
        private bool isOpen;

        protected override bool ShouldUseAlternateText()
        {
            return isOpen;
        }

        public override void Interact(InteractionResult result)
        {
            isOpen = !isOpen;
            Debug.Log(isOpen ? "Door opened" : "Door closed");
        }
    }
}