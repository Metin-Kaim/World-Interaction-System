using Assets.WorldInteractionSystem.Scripts.Datas.UnityValues;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.WorldInteractionSystem.Scripts.Canvas
{
    public class KeyPanelHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI keyCountText;
        [SerializeField] private Image keyImage;

        private KeyData m_keyData;
        private int m_keyCount;

        private Action<KeyPanelHandler> m_onDisableCell;

        public KeyData KeyData => m_keyData;

        private void OnDisable()
        {
            m_onDisableCell.Invoke(this);
        }

        public void Init(KeyData keyData, Color color, Action<KeyPanelHandler> OnDisableCell)
        {
            m_keyData = keyData;
            m_onDisableCell = OnDisableCell;
            keyImage.color = color;
        }

        public void AdjustKeyCount(int count)
        {
            m_keyCount = count;

            m_keyCount = Mathf.Max(m_keyCount, 0);

            keyCountText.text = m_keyCount.ToString();

            if (m_keyCount <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}