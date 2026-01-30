using Assets.WorldInteractionSystem.Scripts.Enums;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Datas.UnityValues
{
    [CreateAssetMenu(menuName = "Custom/Interaction Data")]
    public class InteractionData : ScriptableObject
    {
        [Header("Capabilities")]
        public InteractionCapabilities capabilities;

        [Header("UI")]
        public string defaultText;

        public bool useAlternateText;

        public string alternateText;

        public bool showProgress;
    }
}