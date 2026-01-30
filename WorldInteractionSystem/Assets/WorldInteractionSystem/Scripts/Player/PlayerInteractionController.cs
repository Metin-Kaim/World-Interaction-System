using Assets.WorldInteractionSystem.Scripts.Abstracts;
using Assets.WorldInteractionSystem.Scripts.Canvas;
using Assets.WorldInteractionSystem.Scripts.Datas.Interactions;
using Assets.WorldInteractionSystem.Scripts.Enums;
using Assets.WorldInteractionSystem.Scripts.Signals;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Player
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [Header("Interaction Settings")]
        [SerializeField] private float pressThreshold = 0.25f;
        [SerializeField] private float holdThreshold = 0.75f;
        [SerializeField] private float rayDistance = 3f;
        [SerializeField] private LayerMask interactableLayers;

        [Header("References")]
        [SerializeField] private UnityEngine.Camera playerCamera;
        [SerializeField] private InteractionUIController uiController;

        private IInteractable currentInteractable;

        private bool previousInput;
        private bool interactionConsumed;
        private bool inputLockedUntilRelease;
        private float holdTimer;

        private void Update()
        {
            DetectInteractable();
            HandleInput();
            UpdateUI();
        }

        #region Detection
        private void DetectInteractable()
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, interactableLayers))
            {
                currentInteractable = hit.collider.GetComponent<IInteractable>();
            }
            else
            {
                currentInteractable = null;
            }
        }
        #endregion

        #region Input
        private void HandleInput()
        {
            bool input = InputSignals.Instance.OnGetInteractionValue.Invoke();

            // 🔒 INPUT KİLİTLİYSE
            if (inputLockedUntilRelease)
            {
                if (!input)
                {
                    // Tuş bırakıldı → kilidi aç
                    inputLockedUntilRelease = false;
                    interactionConsumed = false;
                    holdTimer = 0f;
                }

                previousInput = input;
                return;
            }

            if (currentInteractable == null || !currentInteractable.CanInteract)
            {
                previousInput = input;
                return;
            }

            // HOLD FLOW
            if (input && !interactionConsumed)
            {
                holdTimer += Time.deltaTime;

                if (currentInteractable.Capabilities.HasFlag(InteractionCapabilities.Hold) &&
                    holdTimer >= holdThreshold)
                {
                    currentInteractable.Interact(new InteractionResult
                    {
                        Type = InteractionType.Hold,
                        HoldTime = holdTimer
                    });

                    // ✅ HOLD TETİKLENDİ
                    interactionConsumed = true;
                    inputLockedUntilRelease = true;

                    // 🔥 Progress sıfırla
                    uiController.UpdateProgress(0f);
                }
            }

            // PRESS FLOW
            if (!input && previousInput && !interactionConsumed)
            {
                if (currentInteractable.Capabilities.HasFlag(InteractionCapabilities.Press) &&
                    holdTimer <= pressThreshold)
                {
                    currentInteractable.Interact(new InteractionResult
                    {
                        Type = InteractionType.Press,
                        HoldTime = holdTimer
                    });
                }

                holdTimer = 0f;
            }

            previousInput = input;
        }

        #endregion

        #region UI
        private void UpdateUI()
        {
            if (currentInteractable == null ||
                !currentInteractable.CanInteract ||
                inputLockedUntilRelease)
            {
                uiController.Hide();
                return;
            }

            uiController.Show(currentInteractable.GetUIData());

            if (currentInteractable.Capabilities.HasFlag(InteractionCapabilities.Hold))
            {
                float normalized = Mathf.Clamp01(holdTimer / holdThreshold);
                uiController.UpdateProgress(normalized);
            }
        }

        #endregion
    }

}