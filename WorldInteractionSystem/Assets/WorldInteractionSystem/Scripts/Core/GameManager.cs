using System.Collections;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}