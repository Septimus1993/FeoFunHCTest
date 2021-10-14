using UnityEngine;
using Zenject;
using HCTest.PlayerScripts;

namespace HCTest.CubeScripts
{
    public class CubeController : MonoBehaviour
    {
        private GameScripts.Game _game;
        private Player _player;
        private CubeSettings _cubeSettings;
        private MeshFilter _meshFilter;
        
        private BoxCollider _trigger;
       
        private Transform _playerTransform;
        private Transform _neutralsTransform;

        private float extents => _cubeSettings.Extents;
        private bool _isOnGround;

        private Mesh mesh
        {
            get => _meshFilter.mesh;
            set => _meshFilter.mesh = value;
        }

        public new Rigidbody rigidbody { get; private set; }
        public new BoxCollider collider { get; private set; }

        public bool IsOnGround => Physics.Raycast(transform.position, -Vector3.up, extents + 0.1f);

        [Inject] private void Construct(GameScripts.Game game, Player player, CubeSettings cubeSettings, MeshFilter meshFilter, 
            [Inject(Id = "Collider")] BoxCollider collider, [Inject(Id = "Trigger")] BoxCollider trigger, Rigidbody rigidbody,
            [Inject(Id = "Player")] Transform playerTransform, [Inject(Id = "Neutrals")] Transform neutralsTransform)
        {
            _game = game;
            _player = player;
            _cubeSettings = cubeSettings;
            _meshFilter = meshFilter;
            this.collider = collider;
            _trigger = trigger;
            this.rigidbody = rigidbody;
            _playerTransform = playerTransform;
            _neutralsTransform = neutralsTransform;
        }

        private void Awake()
        {
            if (transform.parent == _playerTransform) _player.AddCube(this);
            else SetAsNeutralCube(true);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out CubeController controller))
            {
                _player.AddCube(controller);
                return;
            }

            if (collider.gameObject.name == "Finish Line") _game.Victory();
        }

        public void SetAsNeutralCube(bool start = false)
        {
            transform.parent = _neutralsTransform;
            mesh = _cubeSettings.NeutralCube;
            collider.enabled = !start;
            _trigger.enabled = start;
            if (start) rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            else rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }

        public void SetAsPlayerCube()
        {
            transform.parent = _playerTransform;
            mesh = _cubeSettings.PlayerCube;
            collider.enabled = true;
            _trigger.enabled = false;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
}