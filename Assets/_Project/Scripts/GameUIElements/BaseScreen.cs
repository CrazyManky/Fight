using _Project.Scripts.Audio;
using _Project.Scripts.Services;
using Services;
using UnityEngine;

namespace _Project.Scripts.GameUIElements
{
    public abstract class BaseScreen : MonoBehaviour
    {
        protected AudioManager AudioManager;
        protected GameUIScreen GameScreen;
        protected FreezeService FreezeService;

        public virtual void Init()
        {
            GameScreen = ServiceLocator.Instance.GetService<GameUIScreen>();
            FreezeService = ServiceLocator.Instance.GetService<FreezeService>();
            AudioManager = ServiceLocator.Instance.GetService<AudioManager>();
            FreezeService.FreezeExecute();
            AudioManager.GameSoundStop();
        }

        public virtual void Сlose()
        {
            AudioManager.PlayGame();
            FreezeService.FreezeDisable();
            Destroy(gameObject);
        }
    }
}