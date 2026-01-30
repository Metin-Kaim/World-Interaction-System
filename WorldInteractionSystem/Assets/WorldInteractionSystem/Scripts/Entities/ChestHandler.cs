using Assets.WorldInteractionSystem.Scripts.Abstracts;
using Assets.WorldInteractionSystem.Scripts.Datas.DataValues;
using Assets.WorldInteractionSystem.Scripts.Datas.UnityValues;
using Assets.WorldInteractionSystem.Scripts.Enums;
using Assets.WorldInteractionSystem.Scripts.Signals;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Entities
{
    public class ChestHandler : BaseInteractable
    {
        private bool isOpened;

        public override bool CanInteract => !isOpened;

        public override void Interact(InteractionResult result)
        {
            isOpened = true;
        }
    }
}