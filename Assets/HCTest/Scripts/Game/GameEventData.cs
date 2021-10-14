using UnityEngine;
using Zenject;

namespace HCTest.GameScripts
{
    [CreateAssetMenu(fileName = "GameEventData", menuName = "HCTest/Event Data/Game")]
    public class GameEventData : ScriptableObject, IGame
    {
        private Game _game;

        [Inject] private void Construct(Game game)
        {
            _game = game;
        }

        public void Start()
        {
            _game.Start();
        }

        public void Restart()
        {
            _game.Restart();
        }

        public void Quit()
        {
            _game.Quit();
        }

        public void GameOver()
        {
            _game.GameOver();
        }

        public void Victory()
        {
            _game.Victory();
        }
    }
}