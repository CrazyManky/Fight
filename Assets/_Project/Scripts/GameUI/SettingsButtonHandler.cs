using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.GameUI
{
    [Serializable]
    public class SettingsButtonHandler
    {
        [Header("Sound")] 
        [SerializeField] private Image _buttonSoundOn;
        [SerializeField] private Image _buttonSoundOff;
        [Header("Music")] 
        [SerializeField] private Image _spriteMusicOnActive;
        [SerializeField] private Image _spriteMusicOffDisable;
        [Header("Sprites")]
        [SerializeField] private Sprite _spriteActive;
        [SerializeField] private Sprite _spriteDisable;
 

        public void SwitchSpriteSound(bool value)
        {
            if (value)
            {
                _buttonSoundOn.sprite = _spriteActive;
                _buttonSoundOff.sprite = _spriteDisable;
            }
            else
            {
                _buttonSoundOn.sprite = _spriteDisable;
                _buttonSoundOff.sprite = _spriteActive;
            }
        }

        public void SwitchSpriteMusic(bool value)
        {
            if (value)
            {
                _spriteMusicOnActive.sprite = _spriteActive;
                _spriteMusicOffDisable.sprite = _spriteDisable;
            }
            else
            {
                _spriteMusicOffDisable.sprite = _spriteActive;
                _spriteMusicOnActive.sprite = _spriteDisable;
            }
        }
    }
}