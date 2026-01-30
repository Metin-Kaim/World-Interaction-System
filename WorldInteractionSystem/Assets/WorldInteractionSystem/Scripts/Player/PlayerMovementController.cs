using Assets.WorldInteractionSystem.Scripts.Signals;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float m_moveSpeed = 5f;

    [Header("Rotation")]
    [SerializeField] private float m_horizontalMouseSensitivity = 200f;

    private Rigidbody m_rigidbody;
    private Vector2 m_moveInput;
    private float m_rotationInput;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        // Fizik ayarları (kritik)
        m_rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        m_rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        m_rigidbody.freezeRotation = true; // X ve Z otomatik kilitlenir
    }

    private void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void ReadInput()
    {
        m_moveInput = InputSignals.Instance.OnGetMoveValue.Invoke();

        Vector2 lookInput = InputSignals.Instance.OnGetLookInput.Invoke();
        m_rotationInput = lookInput.x * m_horizontalMouseSensitivity * Time.deltaTime;
    }

    private void Move()
    {
        Vector3 moveDirection =
            transform.forward * m_moveInput.y +
            transform.right * m_moveInput.x;

        Vector3 targetVelocity = moveDirection * m_moveSpeed;

        m_rigidbody.linearVelocity = new Vector3(
            targetVelocity.x,
            m_rigidbody.linearVelocity.y,
            targetVelocity.z
        );
    }

    private void Rotate()
    {
        Quaternion deltaRotation =
            Quaternion.Euler(0f, m_rotationInput, 0f);

        m_rigidbody.MoveRotation(m_rigidbody.rotation * deltaRotation);
    }
}
