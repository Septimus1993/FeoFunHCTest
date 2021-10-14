using UnityEngine;

namespace HCTest.PlayerScripts
{
    [System.Serializable] public class CubeSettings
    {
        [SerializeField] private float extents = 0.5f;
        [SerializeField] private Mesh _playerCube;
        [SerializeField] private Mesh _neutralCubeCube;

        public float Extents => extents;
        public Mesh PlayerCube => _playerCube;
        public Mesh NeutralCube => _neutralCubeCube;
    }
}