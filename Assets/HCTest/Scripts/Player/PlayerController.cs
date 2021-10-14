using UnityEngine;
using Zenject;
using HCTest.GameScripts;

namespace HCTest.PlayerScripts
{
    public class PlayerController : MonoBehaviour, IPlayerControls, IPlayerSettings
    {
        private Game _game;
        private Player _player;
        private PlayerSettings _settings;
        
        private bool _isPreparingToJump;
        private float _currentHeight;

        public float MoveSpeed => _settings.MoveSpeed;
        public float JumpAcceleration => _settings.JumpAcceleration;
        public float JumpMinSpeed => _settings.JumpMinSpeed;
        public float JumpMaxSpeed => _settings.JumpMaxSpeed;

        [Inject] private void Construct(Game game, Player player, PlayerSettings playerSettings)
        {
            _game = game;
            _player = player;
            _settings = playerSettings;

            _game.OnStart += () => enabled = true;
            _game.OnFinish += () => enabled = false;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Update()
        {
            if (_isPreparingToJump) IncreaseHeight();
        }

        private void Move()
        {
            var velocity = _player.rigidbody.velocity;
            velocity.x = -MoveSpeed;
            _player.rigidbody.velocity = velocity;
        }

        public void PrepareJump()
        {
            if (!_player.isOnGround) return;

            _isPreparingToJump = true;
            ResetHeight();
        }

        public void Jump()
        {
            if (!_isPreparingToJump) return;

            _isPreparingToJump = false;
            if (enabled) _player.rigidbody.velocity = _currentHeight * Vector3.up;
            _currentHeight = 0;
        }

        private void ResetHeight()
        {
            _currentHeight = JumpMinSpeed;
        }

        private void IncreaseHeight()
        {
            _currentHeight = Mathf.Clamp(_currentHeight + JumpAcceleration * Time.deltaTime, JumpMinSpeed, JumpMaxSpeed);
        }
    }
}