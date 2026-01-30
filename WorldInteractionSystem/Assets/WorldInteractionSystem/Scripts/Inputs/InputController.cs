using Assets.WorldInteractionSystem.Scripts.Signals;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.WorldInteractionSystem.Scripts.Inputs
{
    public class InputController : MonoBehaviour
    {
        private InputSystem_Actions m_inputActions;
        private InputSystem_Actions.PlayerActions m_playerActions;

        private Vector2 m_moveInput;
        private Vector2 m_lookInput;
        private bool m_isPressingInteractionKey;

        private void Awake()
        {
            m_inputActions = new InputSystem_Actions();
            m_playerActions = m_inputActions.Player;

            m_playerActions.Move.performed += OnMove;
            m_playerActions.Move.canceled += OnMove;
            m_playerActions.Look.performed += OnLook;
            m_playerActions.Look.canceled += OnLook;
            m_playerActions.Interact.performed += OnInteract;
            m_playerActions.Interact.canceled += OnInteract;
        }

        private void OnEnable()
        {
            m_playerActions.Enable();

            InputSignals.Instance.OnGetMoveInput += OnGetMoveInput;
            InputSignals.Instance.OnGetLookInput += OnGetLookInput;
            InputSignals.Instance.OnGetInteractionValue += OnGetInteractionValue;
        }

        private void OnDisable()
        {
            m_playerActions.Disable();

            InputSignals.Instance.OnGetMoveInput -= OnGetMoveInput;
            InputSignals.Instance.OnGetLookInput -= OnGetLookInput;
            InputSignals.Instance.OnGetInteractionValue -= OnGetInteractionValue;
        }

        private void OnDestroy()
        {
            m_playerActions.Move.performed -= OnMove;
            m_playerActions.Move.canceled -= OnMove;
            m_playerActions.Look.performed -= OnLook;
            m_playerActions.Look.canceled -= OnLook;
            m_playerActions.Interact.performed -= OnInteract;
            m_playerActions.Interact.canceled -= OnInteract;

            m_playerActions.Disable();
        }
        private void OnInteract(InputAction.CallbackContext context)
        {
            m_isPressingInteractionKey = context.ReadValueAsButton();
        }

        private void OnLook(InputAction.CallbackContext context)
        {
            m_lookInput = context.ReadValue<Vector2>();
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            m_moveInput = context.ReadValue<Vector2>();
        }

        private Vector2 OnGetMoveInput()
        {
            return m_moveInput;
        }
        private Vector2 OnGetLookInput()
        {
            return m_lookInput;
        }
        private bool OnGetInteractionValue()
        {
            return m_isPressingInteractionKey;
        }

    }

}