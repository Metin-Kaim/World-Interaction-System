using Assets.WorldInteractionSystem.Scripts.Datas.DataValues;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.WorldInteractionSystem.Scripts.Canvas
{
    public class InteractionUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI interactionText;
        [SerializeField] private Image progressBar;

        public void Show(InteractionUIData data)
        {
            interactionText.text = data.Text;
            interactionText.gameObject.SetActive(true);

            progressBar.gameObject.SetActive(data.ShowProgress);
        }

        public void Hide()
        {
            interactionText.gameObject.SetActive(false);
            progressBar.gameObject.SetActive(false);
        }

        public void UpdateProgress(float normalized)
        {
            if (!progressBar.gameObject.activeSelf) return;
            progressBar.fillAmount = normalized;
        }
    }

}
