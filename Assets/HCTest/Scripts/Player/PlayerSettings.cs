using UnityEngine;

namespace HCTest.PlayerScripts
{
    [System.Serializable] public class PlayerSettings : IPlayerSettings
    {
        [SerializeField] private float _moveSpeed = 15f;
        [SerializeField] private float _jumpAcceleration = 7.5f;
        [SerializeField] private float _jumpMinSpeed = 10.5f;
        [SerializeField] private float _jumpMaxSpeed = 18f;

        public float MoveSpeed => _moveSpeed;
        public float JumpAcceleration => _jumpAcceleration;
        public float JumpMinSpeed => _jumpMinSpeed;
        public float JumpMaxSpeed => _jumpMaxSpeed;
    }
}