using System;
using _Project.Screpts.Services;
using _Project.Scripts.Audio;
using _Project.Scripts.GameUIElements.Settings;
using _Project.Scripts.GameUIElements.Shop;
using _Project.Scripts.Services;
using _Project.Scripts.Skills;
using _Project.Scripts.SOConfigs;
using Services;
using UnityEngine;

namespace _Project.Scripts.GameUIElements
{
    public class GameUIScreen : MonoBehaviour, IService
    {
        [field: SerializeField] private Transform _charactersSpawnPoint;
        [field: SerializeField] private EnemyInstance _enemyInstance;
        [SerializeField] private RespectView _respectView;
        [SerializeField] private CharactersConfig _characters;
        [SerializeField] private SettingsView _settings;
        [SerializeField] private ShopScreen _shopScreen;
        [SerializeField] private LoseScreen _loseScreen;
        [SerializeField] private WinScreen _winScreen;
        [SerializeField] private AudioManager _audioManager;

        private FreezeService _freezeService;
        public CharacterInstance CharacterInstance { get; private set; }
        private BaseScreen _baseScreenInstance;
        private DamageService _damageService;
        private RestartService _restartService;

        private void Awake()
        {
            Buffs.Load();
            ServiceLocator.Init();
            _freezeService = new FreezeService();
            _restartService = new RestartService();
            CharacterInstance = new CharacterInstance(_characters, _charactersSpawnPoint);
            ServiceLocator.Instance.AddService(_restartService);
            ServiceLocator.Instance.AddService(_freezeService);
            ServiceLocator.Instance.AddService(CharacterInstance);
            ServiceLocator.Instance.AddService(_audioManager);
            _damageService = new DamageService();
            _freezeService.AddFreezeItem(_enemyInstance);
            _restartService.AddRestartItem(_enemyInstance);
            _restartService.AddRestartItem(_respectView);
            ServiceLocator.Instance.AddService(_damageService);
            ServiceLocator.Instance.AddService(this);
            ServiceLocator.Instance.AddService(_respectView);
            CharacterInstance.InstanceCharacter();
        }

        private void Start()
        {
            _audioManager.PlayGame();
        }

        public void ShowSettingsScreen()
        {
            _audioManager.PlayButtonClick();
            ShowScreen(_settings);
        }

        public void ShowShopScreen()
        {
            _audioManager.PlayButtonClick();
            ShowScreen(_shopScreen);
        }

        public void ShowLoseScreen()
        {
            ShowScreen(_loseScreen);
        }

        public void ShowWinScreen()
        {
            ShowScreen(_winScreen);
        }

        private void ShowScreen(BaseScreen screen)
        {
            _baseScreenInstance = Instantiate(screen, transform);
            _baseScreenInstance.Init();
        }
    }
}