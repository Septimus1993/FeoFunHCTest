namespace HCEngine.GameScripts
{
    public abstract class BaseGame : IBaseGame
    {
        public abstract void Start();
        public abstract void GameOver();
        public abstract void Quit();
    }
}
