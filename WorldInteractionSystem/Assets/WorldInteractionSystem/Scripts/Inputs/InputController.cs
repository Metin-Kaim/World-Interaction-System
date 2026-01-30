using Assets.WorldInteractionSystem.Scripts.Signals;
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

        private void Awake()
        {
            m_inputActions = new InputSystem_Actions();
            m_playerActions = m_inputActions.Player;

            m_playerActions.Move.performed += OnMove;
            m_playerActions.Move.canceled += OnMove;
            m_playerActions.Look.performed += OnLook;
            m_playerActions.Look.canceled += OnLook;
        }

        private void OnEnable()
        {
            m_playerActions.Enable();

            InputSignals.Instance.OnGetMoveValue += OnGetMoveInput;
            InputSignals.Instance.OnGetLookInput += OnGetLookInput;
        }

        private void OnDisable()
        {
            m_playerActions.Disable();

            InputSignals.Instance.OnGetMoveValue -= OnGetMoveInput;
            InputSignals.Instance.OnGetLookInput -= OnGetLookInput;
        }

        private void OnDestroy()
        {
            m_playerActions.Move.performed -= OnMove;
            m_playerActions.Move.canceled -= OnMove;
            m_playerActions.Look.performed -= OnLook;
            m_playerActions.Look.canceled -= OnLook;

            m_playerActions.Disable();
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
    }

}