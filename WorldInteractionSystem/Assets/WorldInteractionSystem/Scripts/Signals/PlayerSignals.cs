using Assets.WorldInteractionSystem.Scripts.Datas.UnityValues;
using Assets.WorldInteractionSystem.Scripts.Enums;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.WorldInteractionSystem.Scripts.Signals
{
    public class PlayerSignals : MonoBehaviour
    {
        public static PlayerSignals Instance;

        public Func<KeyData, bool> HasKey = (keyType) => false;
        public UnityAction<KeyData> OnAddKey = delegate { };
        public UnityAction<KeyData> OnConsumeKey = delegate { };
        public UnityAction<KeyData, int> OnKeyChanged = delegate { };

        private void Awake()
        {
            Instance = this;
        }
    }
}