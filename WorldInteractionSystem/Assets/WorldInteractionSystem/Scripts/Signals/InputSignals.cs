using System;
using System.Collections;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Signals
{
    public class InputSignals : MonoBehaviour
    {
        public static InputSignals Instance { get; private set; }

        public Func<Vector2> OnGetMoveValue = () => Vector2.zero;
        public Func<Vector2> OnGetLookInput = () => Vector2.zero;

        private void Awake()
        {
            Instance = this;
        }
    }
}