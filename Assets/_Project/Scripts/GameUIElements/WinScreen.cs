using System;
using _Project.Scripts.Services;
using Services;

namespace _Project.Scripts.GameUIElements
{
    public class WinScreen : BaseScreen
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
            GameScreen.ShowShopScreen();
            _restartService.Restart();
            Destroy(gameObject);
        }

        public void Continue()
        {
            AudioManager.PlayButtonClick();
            _freezeService.FreezeDisable();
            _restartService.Restart();
            Destroy(gameObject);
        }
    }
}