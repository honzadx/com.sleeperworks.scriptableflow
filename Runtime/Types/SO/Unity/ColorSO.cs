using UnityEngine;

namespace ScriptableFlow.Runtime.Types
{
    public class ColorSO : ValueSOT<Color>
    {
        public static implicit operator Color (ColorSO colorSO) => colorSO.value;
    }
}