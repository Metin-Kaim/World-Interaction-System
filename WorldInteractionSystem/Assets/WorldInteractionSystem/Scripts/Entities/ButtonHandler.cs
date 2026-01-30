using Assets.WorldInteractionSystem.Scripts.Abstracts;
using Assets.WorldInteractionSystem.Scripts.Datas.DataValues;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.WorldInteractionSystem.Scripts.Entities
{
    public class ButtonHandler : BaseInteractable
    {
        [Header("References")]
        [SerializeField] private Transform m_button;
        [SerializeField] private AudioSource m_buttonAudioSource;
        [Header("Animation Values")]
        [SerializeField] private float m_buttonAnimDuration;
        [SerializeField] private float m_buttonTurnOnPositionX;
        [SerializeField] private float m_buttonTurnOffPositionX;
        [Header("Sound Values")]
        [SerializeField] private AudioClip m_turnOnButtonSound;
        [SerializeField] private AudioClip m_turnOffButtonSound;
        [Header("Trigger Events")]
        [SerializeField] private UnityEvent<bool> m_onClick;

        private bool isOpen;

        protected override bool ShouldUseAlternateText()
        {
            return isOpen;
        }

        public override void Interact(InteractionResult result)
        {
            CanInteract = false;

            isOpen = !isOpen;

            m_onClick.Invoke(isOpen);

            m_buttonAudioSource.PlayOneShot(isOpen ? m_turnOnButtonSound : m_turnOffButtonSound);

            m_button.DOLocalMoveX(isOpen ? m_buttonTurnOnPositionX : m_buttonTurnOffPositionX, m_buttonAnimDuration).SetEase(Ease.OutBack).OnComplete(() => CanInteract = true);
        }
    }
}