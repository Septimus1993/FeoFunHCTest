using System;
using UnityEngine.SceneManagement;
using HCEngine.DataScripts;
using HCEngine.GameScripts;
using Zenject;

namespace HCTest.GameScripts
{
    class Game : MainGame, IGame
    {
        public event Action OnStart;
        public event Action OnFinish;
        public event Action OnGameOver;
        public event Action OnVictory;

        [Inject] private void Construct([Inject(Id = "Start")] ScriptableEvent startEvent, [Inject(Id = "Finish")] ScriptableEvent finishEvent, 
            [Inject(Id = "GameOver")] ScriptableEvent gameOverEvent, [Inject(Id = "Victory")] ScriptableEvent victoryEvent)
        {
            OnStart = startEvent.Invoke;
            OnFinish = finishEvent.Invoke;
            OnGameOver = gameOverEvent.Invoke;
            OnVictory = victoryEvent.Invoke;
            
            OnGameOver += () => OnFinish.Invoke();
            OnVictory += () => OnFinish.Invoke();
        }

        public override void Start()
        {
            OnStart.Invoke();
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public override void GameOver()
        {
            OnGameOver.Invoke();
        }

        public void Victory()
        {
            OnVictory.Invoke();
        }
    }
}
