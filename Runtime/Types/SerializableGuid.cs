using System;
using UnityEngine;

namespace ScriptableFlow.Runtime
{
    [Serializable]
    public struct SerializableGuid
    {
        [field: SerializeField] public bool isValid { get; private set; }
        [field: SerializeField] public string guid { get; private set; }
        
        private SerializableGuid(Guid inGuid)
        {
            isValid = true;
            guid = inGuid.ToString();
        }

        public Guid ToGuid()
        {
            return Guid.Parse(guid);
        }

        public static SerializableGuid NewGuid()
        {
            return new(Guid.NewGuid());
        }
    }
}