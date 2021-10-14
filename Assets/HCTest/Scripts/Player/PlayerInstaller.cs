using UnityEngine;
using Zenject;

namespace HCTest.PlayerScripts
{
    [CreateAssetMenu(fileName = "PlayerInstaller", menuName = "HCTest/Installers/Player")]
    public class PlayerInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerControlsEventData _controlsEventData;
        
        public override void InstallBindings()
        {
            Container.Bind<Player>().AsSingle();
            Container.Inject(_controlsEventData);
        }
    }
}
