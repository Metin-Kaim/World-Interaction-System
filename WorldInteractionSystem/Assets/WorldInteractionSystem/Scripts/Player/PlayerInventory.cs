using Assets.WorldInteractionSystem.Scripts.Datas.UnityValues;
using Assets.WorldInteractionSystem.Scripts.Signals;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        private Dictionary<KeyData, int> keys = new Dictionary<KeyData, int>();

        private void OnEnable()
        {
            PlayerSignals.Instance.HasKey += HasKey;
            PlayerSignals.Instance.OnAddKey += AddKey;
            PlayerSignals.Instance.OnConsumeKey += ConsumeKey;
        }
        private void OnDisable()
        {
            PlayerSignals.Instance.HasKey -= HasKey;
            PlayerSignals.Instance.OnAddKey += AddKey;
            PlayerSignals.Instance.OnConsumeKey += ConsumeKey;
        }

        #region Public API

        public void AddKey(KeyData key)
        {
            if (key == null) return;

            if (!keys.ContainsKey(key))
                keys[key] = 0;

            keys[key]++;

            PlayerSignals.Instance.OnKeyChanged?.Invoke(key, keys[key]);
        }

        public bool HasKey(KeyData key)
        {
            if (key == null) return false;
            return keys.ContainsKey(key) && keys[key] > 0;
        }

        public int GetKeyCount(KeyData key)
        {
            if (key == null) return 0;
            return keys.TryGetValue(key, out int count) ? count : 0;
        }

        public void ConsumeKey(KeyData key)
        {
            if (!HasKey(key)) return;

            keys[key]--;

            if (keys[key] <= 0)
                keys.Remove(key);

            PlayerSignals.Instance.OnKeyChanged?.Invoke(key, GetKeyCount(key));
        }

        public IReadOnlyDictionary<KeyData, int> GetAllKeys()
        {
            return keys;
        }

        #endregion
    }

}