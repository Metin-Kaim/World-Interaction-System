using Assets.WorldInteractionSystem.Scripts.Datas.DataValues;
using Assets.WorldInteractionSystem.Scripts.Datas.UnityValues;
using Assets.WorldInteractionSystem.Scripts.Enums;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Abstracts
{

    public abstract class BaseInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] protected InteractionData interactionData;

        public virtual bool CanInteract { get; set; }

        public InteractionCapabilities Capabilities =>
            interactionData != null
                ? interactionData.capabilities
                : InteractionCapabilities.None;

        protected virtual void Start()
        {
            CanInteract = true;
        }

        public virtual InteractionUIData GetUIData()
        {
            if (interactionData == null)
                return default;

            string text = interactionData.defaultText;

            if (interactionData.useAlternateText &&
                ShouldUseAlternateText() &&
                !string.IsNullOrEmpty(interactionData.alternateText))
            {
                text = interactionData.alternateText;
            }

            // 🔹 INSTANCE-SPECIFIC TEXT FORMAT
            text = FormatUIText(text);

            return new InteractionUIData
            {
                Text = text,
                ShowProgress = interactionData.showProgress
            };
        }
        protected virtual string FormatUIText(string rawText)
        {
            return rawText;
        }
        protected virtual bool ShouldUseAlternateText()
        {
            return false;
        }

        public abstract void Interact(InteractionResult result);
    }
}
