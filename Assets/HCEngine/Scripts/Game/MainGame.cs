using UnityEngine;

namespace HCEngine.GameScripts
{
    public abstract class MainGame : BaseGame
    {
        public override void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
