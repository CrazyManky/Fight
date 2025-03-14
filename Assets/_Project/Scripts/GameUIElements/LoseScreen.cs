using System;
using _Project.Scripts.Services;
using Services;

namespace _Project.Scripts.GameUIElements
{
    public class LoseScreen : BaseScreen
    {
        private RestartService _restartService;
        private FreezeService _freezeService;

        private void Awake()
        {
            _restartService = ServiceLocator.Instance.GetService<RestartService>();
            _freezeService = ServiceLocator.Instance.GetService<FreezeService>();
        }

        public void ShowShopScreen()
        {
            AudioManager.PlayButtonClick();
            _freezeService.FreezeDisable();
            GameScreen.ShowShopScreen();
            Destroy(gameObject);
        }

        public void Restart()
        {
            AudioManager.PlayButtonClick();
            _freezeService.FreezeDisable();
            _restartService.Restart();
            Destroy(gameObject);
        }
    }
}