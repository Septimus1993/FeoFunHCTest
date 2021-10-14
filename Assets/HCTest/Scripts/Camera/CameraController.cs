using UnityEngine;
using Zenject;
using HCTest.PlayerScripts;

namespace HCTest.CameraScripts
{
    public class CameraController : MonoBehaviour, ICameraSettings
    {
        private Camera _camera;
        private CameraSettings _settings;
        private Player _player;

        private Transform _currentTarget;
        private float _currentAngleX;
        private float _currentDistance;
        private float _currentHeight;

        public float Speed => _settings.Speed;
        public float AngleX => _settings.AngleX;
        public float AngleStep => _settings.AngleStep;
        public float Distance => _settings.Distance;
        public float DistanceStep => _settings.DistanceStep;
        public Vector3 Offset => _settings.Offset;

        private float targetAngleX => AngleX - _player.CubeCount * AngleStep;
        private float targetHeight => _player.CenterPosition.y;
        private float targetDistance => Distance + _player.CubeCount * DistanceStep;

        [Inject] private void Construct(CameraSettings settings, Camera camera, Player player)
        {
            _settings = settings;
            _camera = camera;
            _player = player;
        }

        private void Start()
        {
            ResetPosition();
        }

        private void LateUpdate()
        {
            UpdatePosition();
        }

        private void ResetPosition()
        {
            _currentAngleX = targetAngleX;
            transform.localEulerAngles += (_currentAngleX - transform.localEulerAngles.x) * Vector3.right;

            _currentHeight = targetHeight;
            _currentDistance = targetDistance;
            transform.position = CalculatePosition();
        }

        private void UpdatePosition()
        {
            float deltaTime = Speed * Time.deltaTime;

            _currentAngleX = Mathf.Lerp(_currentAngleX, targetAngleX, deltaTime);
            transform.localEulerAngles += (_currentAngleX - transform.localEulerAngles.x) * Vector3.right;

            _currentHeight = Mathf.Lerp(_currentHeight, targetHeight, 0.5f * deltaTime);
            _currentDistance = Mathf.Lerp(_currentDistance, targetDistance, deltaTime);
            transform.position = CalculatePosition();
        }

        private Vector3 CalculatePosition()
        {
            var position = _currentTarget.transform.position;
            position.y = _currentHeight;
            return position + Offset - transform.rotation * Vector3.forward * _currentDistance * 600f / _camera.fieldOfView;
        }

        public void SetTarget(Transform target)
        {
            _currentTarget = target;
        }
    }
}