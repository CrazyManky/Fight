using _Project.Scripts.GameUI;
using _Project.Scripts.GameUI.Settings;
using _Project.Scripts.SOConfigs;
using UnityEngine;

namespace _Project.Scripts.GameUIElements.Settings
{
    public class SettingsView : BaseScreen
    {
        [field: SerializeField] private SettingsButtonHandler _settingsButtonHandler;
        [SerializeField] private SoundConfig _soundConfig;
        [SerializeField] private PrivacyPolicyScreen _policyScreen;
        [SerializeField] private RectTransform _conteiner;

        private void Awake()
        {
            _soundConfig.Load();
            _settingsButtonHandler.SwitchSpriteMusic(_soundConfig.VolumeMusic);
            _settingsButtonHandler.SwitchSpriteSound(_soundConfig.ActiveSound);
        }

        public void DisableSound()
        {
            AudioManager.PlayButtonClick();
            _settingsButtonHandler.SwitchSpriteSound(false);
            _soundConfig.SetDataSound(false);
        }

        public void ActiveSound()
        {
             AudioManager.PlayButtonClick();
            _settingsButtonHandler.SwitchSpriteSound(true);
            _soundConfig.SetDataSound(true);
        }

        public void DisableMusic()
        {
            AudioManager.PlayButtonClick();
            _settingsButtonHandler.SwitchSpriteMusic(false);
            _soundConfig.SetDataMusic(false);
        }

        public void ActiveMusic()
        {
             AudioManager.PlayButtonClick();
            _settingsButtonHandler.SwitchSpriteMusic(true);
            _soundConfig.SetDataMusic(true);
        }

        public void ShowPrivacyPolicy()
        {
            AudioManager.PlayButtonClick();
            Instantiate(_policyScreen, _conteiner);
        }


        public override void Сlose()
        {
            base.Сlose();
        }
    }
}