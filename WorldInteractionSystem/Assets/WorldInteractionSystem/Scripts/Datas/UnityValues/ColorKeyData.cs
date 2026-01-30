using Assets.WorldInteractionSystem.Scripts.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.WorldInteractionSystem.Scripts.Datas.UnityValues
{
    [CreateAssetMenu(menuName = "Custom/Color Key Data")]
    public class ColorKeyData : ScriptableObject
    {
        public List<ColorKeyPair> ColorKeyPairs;
    }

    [Serializable]
    public class ColorKeyPair
    {
        public KeyType KeyType;
        public Color Color;
    }
}
