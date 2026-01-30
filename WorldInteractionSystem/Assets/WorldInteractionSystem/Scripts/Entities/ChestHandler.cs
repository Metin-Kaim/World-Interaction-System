using Assets.WorldInteractionSystem.Scripts.Abstracts;
using Assets.WorldInteractionSystem.Scripts.Datas.DataValues;
using Assets.WorldInteractionSystem.Scripts.Datas.UnityValues;
using DG.Tweening;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Entities
{
    public class ChestHandler : BaseInteractable
    {
        [Header("References")]
        [SerializeField] private Transform m_chestCover;
        [SerializeField] private AudioSource m_chestAudioSource;
        [Header("Animation Values")]
        [SerializeField] private float m_chestAnimDuration;
        [SerializeField] private float m_chestOpeningAngle;
        [Header("Sound Values")]
        [SerializeField] private AudioClip m_openingChestSound;


        public override void Interact(InteractionResult result)
        {
            CanInteract = false;

            m_chestCover.DORotate((m_chestOpeningAngle) * Vector3.right, m_chestAnimDuration).SetEase(Ease.Linear);

            m_chestAudioSource.PlayOneShot(m_openingChestSound);
        }
    }
}