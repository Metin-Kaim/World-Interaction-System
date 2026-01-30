using Assets.WorldInteractionSystem.Scripts.Signals;
using System.Collections;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Camera
{
    public class CameraController : MonoBehaviour
    {
        [Header("Rotation")]
        [SerializeField] private float m_verticalMouseSensitivity = 200f;
        [SerializeField] private float m_minPitch = -80f;
        [SerializeField] private float m_maxPitch = 80f;

        private float m_currentPitch;

        private void LateUpdate()
        {
            RotateCamera();
        }

        private void RotateCamera()
        {
            Vector2 lookInput = InputSignals.Instance.OnGetLookInput.Invoke();

            float mouseY = lookInput.y * m_verticalMouseSensitivity * Time.deltaTime;

            m_currentPitch -= mouseY;
            m_currentPitch = Mathf.Clamp(m_currentPitch, m_minPitch, m_maxPitch);

            transform.localRotation = Quaternion.Euler(m_currentPitch, 0f, 0f);
        }
    }
}