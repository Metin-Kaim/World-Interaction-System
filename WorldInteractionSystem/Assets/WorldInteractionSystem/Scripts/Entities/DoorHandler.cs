using Assets.WorldInteractionSystem.Scripts.Abstracts;
using Assets.WorldInteractionSystem.Scripts.Datas.DataValues;
using DG.Tweening;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Entities
{
    public class DoorHandler : BaseInteractable
    {
        [Header("References")]
        [SerializeField] private Transform m_doorBody;
        [SerializeField] private AudioSource m_doorAudioSource;
        [Header("Animation Values")]
        [SerializeField] private float m_doorAnimDuration;
        [SerializeField] private float m_doorOpeningAngle;
        [Header("Sound Values")]
        [SerializeField] private AudioClip m_openingDoorSound;
        [SerializeField] private AudioClip m_closingDoorSound;

        private bool isOpen;

        protected override bool ShouldUseAlternateText()
        {
            return isOpen;
        }

        public override void Interact(InteractionResult result)
        {
            isOpen = !isOpen;
            CanInteract = false;
            m_doorBody.DORotate((isOpen ? 0 : m_doorOpeningAngle) * Vector3.up, m_doorAnimDuration).SetEase(Ease.Linear).OnComplete(() => CanInteract = true);
            m_doorAudioSource.PlayOneShot(isOpen ? m_openingDoorSound : m_closingDoorSound);
        }


    }
}