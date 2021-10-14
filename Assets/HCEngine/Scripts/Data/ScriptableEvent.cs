using System;
using UnityEngine;
using UnityEngine.Events;

namespace HCEngine.DataScripts
{
    [CreateAssetMenu(fileName = "ScriptableEvent", menuName = "HCTest/Data/Event")]
    public class ScriptableEvent : ScriptableObject
    {
        [SerializeField] private UnityEvent _action;

        public event Action Action
        {
            add => _action.AddListener(new UnityAction(value));
            remove => _action.RemoveListener(new UnityAction(value));
        }

        public void Invoke()
        {
            _action?.Invoke();
        }

        [Serializable] public class Data
        {
            [SerializeField] private ScriptableEvent _scriptableEvent;
            [SerializeField] private UnityEvent _events;

            public void Subscribe()
            {
                _scriptableEvent.Action += Invoke;
            }

            public void Unsubscribe()
            {
                _scriptableEvent.Action -= Invoke;
            }

            private void Invoke()
            {
                _events?.Invoke();
            }
        }
    }
}
