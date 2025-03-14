using System;
using _Project.Scripts.Audio;
using _Project.Scripts.GameUIElements.Shop;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.GameUIElements
{
    public abstract class AbilityButton : MonoBehaviour
    {
        [SerializeField] private GameUIScreen _gameUIScreen;
        [SerializeField] protected Image ImageButton;
        [SerializeField] protected Sprite ReadySprite;
        [SerializeField] protected Sprite DelaySprite;
        [SerializeField] protected Slider Slider;
        [SerializeField] protected float Delay = 5f;
        [SerializeField] private AudioManager _audioManager;

        protected float Step = 0.1f;
        protected bool BuffActive = false;
        protected Coroutine ActiveCoroutine;

        private void Awake()
        {
            Slider.maxValue = Delay;
            Slider.gameObject.SetActive(false);
        }

        public void BaffExecude()
        {
            if (BuffActive)
                return;
            _audioManager.PlayButtonClick();
            _gameUIScreen.CharacterInstance.Attack();
            CoroutineRunner();
        }

        protected abstract void CoroutineRunner();
    }
}