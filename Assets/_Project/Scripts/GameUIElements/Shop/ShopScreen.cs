using _Project.Scripts.GameUI.Shop;
using _Project.Scripts.Skills;
using _Project.Scripts.SOConfigs;
using UnityEngine;

namespace _Project.Scripts.GameUIElements.Shop
{
    public class ShopScreen : BaseScreen
    {
        [SerializeField] private PlayerWallet _playerWallet;
        [field: SerializeField] private levelProgress _levelProgressSpeed;
        [field: SerializeField] private levelProgress _levelProgressDamage;

        private int _price = 5000;

        private void Awake()
        {
            _levelProgressSpeed.ShowLevel(Buffs.LevelSpeed);
            _levelProgressDamage.ShowLevel(Buffs.LevelDamage);
        }

        public void PurchaseSpeedBonus()
        {
            AudioManager.PlayButtonClick();
            if (Buffs.LevelSpeed >= 7)
                return;
            if (_playerWallet.PlayerValue < _price)
                return;
            _playerWallet.RemoveValue(_price);
            Buffs.UpdateSpeed();
            _levelProgressSpeed.ShowLevel(Buffs.LevelSpeed);
        }

        public void PurchaseDamageBonus()
        {
            AudioManager.PlayButtonClick();
            if (Buffs.LevelDamage >= 7)
                return;
            if (_playerWallet.PlayerValue < _price)
                return;
            _playerWallet.RemoveValue(_price);
            Buffs.UpdateDamage();
            _levelProgressDamage.ShowLevel(Buffs.LevelDamage);
        }
    }
}