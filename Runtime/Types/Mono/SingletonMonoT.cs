using UnityEngine;

namespace ScriptableFlow.Runtime.Types
{
    public class SingletonMonoT<T> : MonoBehaviour where T : SingletonMonoT<T>
    {
        private static T _instance;
        public static T instance => _instance;
        
        protected virtual void OnEnable()
        {
            if (instance != null)
            {
                Debug.LogError($"SingletonMonoT<{typeof(T).Name}> instance already set");
                Destroy(gameObject);
                return;
            }
            _instance = this as T;
        }

        protected virtual void OnDisable()
        {
            if (instance != this)
                _instance = null;
        }
    }
}