using System;
using System.Collections.Generic;
using ScriptableFlow.Runtime.Attributes;

namespace ScriptableFlow.Runtime.Types
{
    public interface IEvent { }
    
    [CreateAsset]
    public class EventBusSO : PersistentIdSO
    {
        private readonly Dictionary<Type, object> _events = new();

        public void Broadcast<T>(T value) where T : IEvent
        {
            if (!_events.TryGetValue(typeof(T), out var del))
                return;
            
            ((Action<T>)del)?.Invoke(value);
        }
        
        public void Register<T>(Action<T> callback) where T : IEvent
        {
            if (!_events.TryGetValue(typeof(T), out var del))
                _events[typeof(T)] = callback;
            else
                _events[typeof(T)] = (Action<T>)del + callback;
        }

        public void Unregister<T>(Action<T> callback) where T : IEvent
        {
            if (_events.TryGetValue(typeof(T), out var del))
                _events[typeof(T)] = (Action<T>)del - callback;
        }
    }
}