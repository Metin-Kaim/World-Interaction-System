using Assets.WorldInteractionSystem.Scripts.Datas.DataValues;
using Assets.WorldInteractionSystem.Scripts.Datas.UnityValues;
using Assets.WorldInteractionSystem.Scripts.Enums;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Abstracts
{

    public abstract class BaseInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] protected InteractionData interactionData;

        public virtual bool CanInteract => true;

        public InteractionCapabilities Capabilities =>
            interactionData != null
                ? interactionData.capabilities
                : InteractionCapabilities.None;

        public virtual InteractionUIData GetUIData()
        {
            if (interactionData == null)
                return default;

            string text = interactionData.defaultText;

            if (interactionData.useAlternateText &&
                ShouldUseAlternateText())
            {
                text = interactionData.alternateText;
            }

            return new InteractionUIData
            {
                Text = text,
                ShowProgress = interactionData.showProgress
            };
        }
        protected virtual bool ShouldUseAlternateText()
        {
            return false;
        }

        public abstract void Interact(InteractionResult result);
    }
}
