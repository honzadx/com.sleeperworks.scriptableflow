using ScriptableFlow.Runtime.Attributes;
using UnityEngine;

namespace ScriptableFlow.Runtime.Types
{
    [CreateAsset]
    public class PersistentIdSO : ScriptableObject
    {
        [SerializeField] private SerializableGuid _guid = SerializableGuid.NewGuid();
    }
}