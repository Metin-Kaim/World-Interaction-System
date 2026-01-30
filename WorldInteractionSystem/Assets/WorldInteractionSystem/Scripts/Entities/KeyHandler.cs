using Assets.WorldInteractionSystem.Scripts.Abstracts;
using Assets.WorldInteractionSystem.Scripts.Datas.DataValues;
using Assets.WorldInteractionSystem.Scripts.Datas.UnityValues;
using Assets.WorldInteractionSystem.Scripts.Signals;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Entities
{
    public class KeyHandler : BaseInteractable
    {
        [SerializeField] private KeyData keyData;

        public override void Interact(InteractionResult result)
        {
            PlayerSignals.Instance.OnAddKey.Invoke(keyData);
            gameObject.SetActive(false);
        }
    }
}