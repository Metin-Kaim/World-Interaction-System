using Assets.WorldInteractionSystem.Scripts.Enums;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Datas.UnityValues
{
    [CreateAssetMenu(menuName = "Custom/Key Data")]
    public class KeyData : ScriptableObject
    {
        public KeyType KeyType;
        public string DisplayName;
    }

}