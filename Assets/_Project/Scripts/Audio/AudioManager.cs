using _Project.Screpts.Services;
using _Project.Scripts.SOConfigs;
using UnityEngine;

namespace _Project.Scripts.Audio
{
    public class AudioManager : MonoBehaviour, IService
    {
        [SerializeField] private SoundConfig soundConfig;
        [SerializeField] private AudioSource _buttonClickListener;
        [SerializeField] private AudioSource _gameSound;

        private bool _plaingMenu = false;
        private bool _plaingGame = false;


        private void Awake()
        {
            soundConfig.Load();
            SetDataMusic();
            SetSoundData();
        }

        public void PlayButtonClick()
        {
            _buttonClickListener.Play();
        }

        public void PlayGame()
        {
            _gameSound.Play();
        }

        public void GameSoundStop()
        {
            _gameSound.Stop();
        }


        private void SetSoundData()
        {
            if (soundConfig.ActiveSound)
                _buttonClickListener.volume = 1;
            else
                _buttonClickListener.volume = 0;
        }

        private void SetDataMusic()
        {
            if (soundConfig.VolumeMusic)
                _gameSound.volume = 1;
            else
                _gameSound.volume = 0;
        }

        private void Update()
        {
            SetDataMusic();
            SetSoundData();
        }
    }
}