using Assets.WorldInteractionSystem.Scripts.Abstracts;
using Assets.WorldInteractionSystem.Scripts.Datas.DataValues;
using Assets.WorldInteractionSystem.Scripts.Datas.UnityValues;
using Assets.WorldInteractionSystem.Scripts.Signals;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.WorldInteractionSystem.Scripts.Entities
{
    public class LockHandler : BaseInteractable
    {
        [Header("Key Requirement")]
        [SerializeField] private KeyData requiredKey;
        [Header("Trigger Events")]
        [SerializeField] private UnityEvent<bool> m_onClick;

        private bool isOpened;

        public override bool CanInteract => !isOpened;

        protected override bool ShouldUseAlternateText()
        {
            return PlayerSignals.Instance.HasKey.Invoke(requiredKey);
        }

        protected override string FormatUIText(string rawText)
        {
            if (requiredKey == null)
                return rawText;

            return rawText.Replace("{KEY}", requiredKey.DisplayName);
        }

        public override void Interact(InteractionResult result)
        {
            if (!PlayerSignals.Instance.HasKey.Invoke(requiredKey)) return;

            isOpened = true;
            Debug.Log("Lock opened with " + requiredKey.DisplayName);

            m_onClick?.Invoke(isOpened);

            PlayerSignals.Instance.OnConsumeKey.Invoke(requiredKey);

            gameObject.SetActive(false);
        }
    }
}