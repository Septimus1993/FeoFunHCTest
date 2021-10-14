using HCEngine.DataScripts;
using UnityEngine;
using Zenject;

namespace HCTest.GameScripts
{
    [CreateAssetMenu(fileName = "GameInstaller", menuName = "HCTest/Installers/Game")]
    public class GameInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ScriptableEvent[] _scriptableEvents;
        [SerializeField] private GameEventData _gameEventData;

        public override void InstallBindings()
        {
            foreach (var scriptableEvent in _scriptableEvents)
            {
                Container.BindInstance(scriptableEvent).WithId(scriptableEvent.name.Replace("Event", ""));
            }

            Container.Bind<Game>().AsSingle();
            Container.Inject(_gameEventData);
        }
    }
}