using UnityEngine;

namespace ScriptableFlow.Runtime.Types
{
    public class PersistentSingletonMonoT<T> :  MonoBehaviour where T : PersistentSingletonMonoT<T>
    {
        private static T _instance;
        public static T instance => _instance;
        
        protected virtual void Awake()
        {
            if (instance != null)
            {
                Debug.LogError($"PersistentSingletonMonoT<{typeof(T).Name}> instance already set");
                Destroy(gameObject);
                return;
            }
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        
        protected virtual void OnDestroy()
        {
            if (instance != this)
                _instance = null;
        }
    }
}