using UnityEngine;
using Zenject;

namespace HCTest.PlayerScripts
{
    [CreateAssetMenu(fileName = "PlayerControlsEventData", menuName = "HCTest/Event Data/Player Controls")]
    public class PlayerControlsEventData : ScriptableObject, IPlayerControls
    {
        private PlayerController _controller;

        [Inject] private void Construct(PlayerController controller)
        {
            _controller = controller;
        }

        public void PrepareJump()
        {
            _controller.PrepareJump();
        }

        public void Jump()
        {
            _controller.Jump();
        }
    }
}