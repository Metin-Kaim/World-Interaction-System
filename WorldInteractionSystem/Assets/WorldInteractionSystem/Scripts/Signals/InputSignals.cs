using System;
using System.Collections;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Signals
{
    public class InputSignals : MonoBehaviour
    {
        public static InputSignals Instance { get; private set; }

        public Func<Vector2> OnGetMoveInput = () => Vector2.zero;
        public Func<Vector2> OnGetLookInput = () => Vector2.zero;
        public Func<bool> OnGetInteractionValue = () => false;

        private void Awake()
        {
            Instance = this;
        }
    }
}