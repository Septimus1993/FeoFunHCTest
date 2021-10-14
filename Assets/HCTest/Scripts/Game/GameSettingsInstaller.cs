using UnityEngine;
using Zenject;
using HCTest.CameraScripts;
using HCTest.PlayerScripts;

namespace HCTest.GameScripts
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "HCTest/Installers/Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private CameraSettings _cameraSettings;
        [SerializeField] private CubeSettings _cubeSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_cameraSettings);
            Container.BindInstance(_playerSettings);
            Container.BindInstance(_cubeSettings);
        }
    }
}