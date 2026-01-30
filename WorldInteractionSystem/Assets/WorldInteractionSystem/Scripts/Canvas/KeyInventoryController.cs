using Assets.WorldInteractionSystem.Scripts.Datas.UnityValues;
using Assets.WorldInteractionSystem.Scripts.Signals;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Canvas
{
    public class KeyInventoryController : MonoBehaviour
    {
        [SerializeField] private KeyPanelHandler KeyHolderPrefab;
        [SerializeField] private ColorKeyData m_colorKeyData;

        private List<KeyPanelHandler> m_activeInventoryCells;
        private List<KeyPanelHandler> m_deactiveInventoryCells;

        private void Awake()
        {
            m_activeInventoryCells = new List<KeyPanelHandler>();
            m_deactiveInventoryCells = new List<KeyPanelHandler>();
        }

        private void OnEnable()
        {
            PlayerSignals.Instance.OnKeyChanged += OnKeyChanged;
        }
        private void OnDisable()
        {
            PlayerSignals.Instance.OnKeyChanged -= OnKeyChanged;
        }

        private void OnKeyChanged(KeyData keyData, int count)
        {
            KeyPanelHandler selectedCellHandler = null;

            if (m_activeInventoryCells.Count <= 0 || m_activeInventoryCells.FirstOrDefault(x => x.KeyData == keyData) == null)
            {
                if (m_deactiveInventoryCells.Count > 0)
                {
                    selectedCellHandler = m_deactiveInventoryCells[0];
                    m_deactiveInventoryCells.RemoveAt(0);
                    selectedCellHandler.gameObject.SetActive(true);
                }
                else
                {
                    selectedCellHandler = Instantiate(KeyHolderPrefab, transform);
                }

                Color selectedKeyColor = GetKeyColor(keyData);

                selectedCellHandler.Init(keyData, selectedKeyColor, RemoveCellHandlerFromActiveList);
                m_activeInventoryCells.Add(selectedCellHandler);
            }
            else
            {
                selectedCellHandler = m_activeInventoryCells.FirstOrDefault(x => x.KeyData == keyData);
            }
            selectedCellHandler.AdjustKeyCount(count);
        }

        private Color GetKeyColor(KeyData keyData)
        {
            Color selectedKeyColor = Color.white;
            ColorKeyPair colorKeyPair = m_colorKeyData.ColorKeyPairs.FirstOrDefault(x => x.KeyType == keyData.KeyType);
            if (colorKeyPair == null)
            {
                Debug.LogWarning("Wanted color key pair is not valid!");
            }
            else
            {
                selectedKeyColor = colorKeyPair.Color;
            }

            return selectedKeyColor;
        }

        //private void OnAddKey(KeyData keyData, int count)
        //{
        //    KeyPanelHandler selectedCellHandler = null;

        //    if (m_activeInventoryCells.Count <= 0 || m_activeInventoryCells.FirstOrDefault(x => x.KeyData == keyData) == null)
        //    {
        //        if (m_deactiveInventoryCells.Count > 0)
        //        {
        //            selectedCellHandler = m_deactiveInventoryCells[0];
        //            m_deactiveInventoryCells.RemoveAt(0);
        //            selectedCellHandler.gameObject.SetActive(true);
        //        }
        //        else
        //        {
        //            selectedCellHandler = Instantiate(KeyHolderPrefab, transform);
        //        }

        //        selectedCellHandler.Init(keyData, count, RemoveCellHandlerFromActiveList);
        //        m_activeInventoryCells.Add(selectedCellHandler);
        //    }
        //    else
        //    {
        //        selectedCellHandler = m_activeInventoryCells.FirstOrDefault(x => x.KeyData == keyData);
        //    }
        //    selectedCellHandler.IncreaseItemCount(count);
        //}

        //private void OnConsumeKey(KeyData keyData)
        //{
        //    KeyPanelHandler selectedCellHandler = m_activeInventoryCells.FirstOrDefault(x => x.KeyData == keyData);

        //    if (selectedCellHandler != null)
        //    {
        //        selectedCellHandler.DecreaseItemCount();
        //    }
        //    else
        //    {
        //        Debug.LogWarning($"Consuming Failed! There is no key as \"{keyData.KeyType}\" in inventory!");
        //    }
        //}

        public void RemoveCellHandlerFromActiveList(KeyPanelHandler inventoryCellHandler)
        {
            m_activeInventoryCells.Remove(inventoryCellHandler);
            m_deactiveInventoryCells.Add(inventoryCellHandler);
        }
    }
}