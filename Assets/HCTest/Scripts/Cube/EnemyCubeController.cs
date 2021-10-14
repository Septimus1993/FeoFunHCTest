using System.Linq;
using UnityEngine;
using Zenject;
using HCTest.PlayerScripts;

namespace HCTest.CubeScripts
{
    public class EnemyCubeController : MonoBehaviour
    {
        private Player _player;

        private float _heightOffset;
        private float _distanceOffset;

        [Inject] private void Construct(Player player, BoxCollider collider)
        {
            _player = player;
            _heightOffset = collider.size.y * 0.5f - 0.01f;
            _distanceOffset = collider.size.x * 0.5f - 0.01f;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var playerController = collision.gameObject.GetComponentInParent<PlayerController>();
            var controller = collision.gameObject.GetComponent<CubeController>();

            if (playerController == null || controller == null) return;
            if (isBehind(collision) || isAbove(collision)) return;

            _player.RemoveCube();
        }

        private bool isBehind(Collision collision)
        {
            return collision.transform.position.x < transform.position.x + _distanceOffset;
        }

        private bool isAbove(Collision collision)
        {
            foreach (var contact in collision.contacts)
            {
                if (contact.point.y < transform.position.y + _heightOffset) return false;
            }

            return true;
        }
    }
}