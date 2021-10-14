using UnityEngine;

namespace HCTest.CameraScripts
{
    [System.Serializable] public class CameraSettings : ICameraSettings
    {
        [SerializeField] private float _speed = 6f;
        [SerializeField] private float _angleX = 15;
        [SerializeField] private float _angleStep = 0.2f;
        [SerializeField] private float _distance = 1;
        [SerializeField] private float _distanceStep = 0.125f;
        [SerializeField] private Vector3 _offset;

        public float Speed => _speed;
        public float AngleX => _angleX;
        public float AngleStep => _angleStep;
        public float Distance => _distance;
        public float DistanceStep => _distanceStep;
        public Vector3 Offset => _offset;
    }
}