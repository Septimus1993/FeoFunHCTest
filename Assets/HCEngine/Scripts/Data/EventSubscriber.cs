using UnityEngine;

namespace HCEngine.DataScripts
{
    public class EventSubscriber : MonoBehaviour
    {
        [SerializeField] private ScriptableEvent.Data[] _eventDatas;

        private void Awake()
        {
            foreach (var eventData in _eventDatas)
            {
                eventData.Subscribe();
            }
        }

        private void OnDestroy()
        {
            foreach (var eventData in _eventDatas)
            {
                eventData.Unsubscribe();
            }
        }
    }
}