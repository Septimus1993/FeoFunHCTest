using System.Collections.Generic;
using HCTest.CameraScripts;
using UnityEngine;
using Zenject;
using HCTest.CubeScripts;
using HCTest.GameScripts;

namespace HCTest.PlayerScripts
{
    public class Player
    {
        private Game _game;
        private CameraController _cameraController;
        
        private Stack<CubeController> _cubes = new Stack<CubeController>();
        private CubeController firstCube => CubeCount == 0 ? null : _cubes.Peek();

        public Transform transform { get; private set; }
        public Rigidbody rigidbody => CubeCount == 0 ? null : firstCube.rigidbody;
        
        public Vector3 CenterPosition
        {
            get
            {
                if (CubeCount == 0) return transform.position;
                Vector3 sum = Vector3.zero;
                foreach (var cube in _cubes) sum += cube.transform.position;
                return sum /= CubeCount;
            }
        }

        public bool isOnGround => CubeCount != 0 && firstCube.IsOnGround;

        public int CubeCount => _cubes.Count;

        [Inject] private void Construct(Game game, CameraController cameraController, [Inject(Id = "Player")] Transform transform)
        {
            _game = game;
            this.transform = transform;
            _cameraController = cameraController;
        }

        public void AddCube(CubeController cube)
        {
            if (_cubes.Contains(cube)) return;

            cube.SetAsPlayerCube();
            cube.rigidbody.mass = 1;

            _cameraController.SetTarget(cube.transform);

            if (CubeCount > 0)
            {
                var previousCube = firstCube;

                cube.transform.position = previousCube.transform.position;
                cube.rigidbody.velocity = previousCube.rigidbody.velocity;

                previousCube.rigidbody.mass = 0;
                previousCube.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                previousCube.transform.parent = cube.transform;
                previousCube.transform.localPosition = Vector3.up;
            }
            else
            {
                cube.transform.position = transform.position;
            }

            _cubes.Push(cube);
        }

        public void RemoveCube()
        {
            if (CubeCount == 0) return;

            var cube = _cubes.Pop();
            cube.rigidbody.mass = 0;

            if (CubeCount > 0)
            {
                var previousCube = firstCube;

                _cameraController.SetTarget(previousCube.transform);

                previousCube.rigidbody.mass = 1;
                previousCube.transform.parent = cube.transform.parent;
                previousCube.rigidbody.constraints = cube.rigidbody.constraints;
            }

            cube.SetAsNeutralCube();

            if (CubeCount == 0) _game.GameOver();
        }
    }
}
