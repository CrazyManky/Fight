using _Project.Scripts.SOConfigs;
using UnityEngine;

namespace _Project.Scripts.GameUI.Shop
{
    public class ShopScreen : MonoBehaviour
    {
        [SerializeField] private PlayerWallet _playerWallet;
        [field: SerializeField] private levelProgress _levelProgressSpeed;
        [field: SerializeField] private levelProgress _levelProgressDamage;

        private int _price = 5000;

        private int _levelSpeed = 0;
        private int _levelDamage = 0;

        public void PurchaseSpeedBonus()
        {
            if (_playerWallet.PlayerValue < _price)
                return;
            _playerWallet.RemoveValue(_price);
            _levelSpeed++;
            _levelProgressSpeed.ShowLevel(_levelSpeed);
        }

        public void PurchaseDamageBonus()
        {
            if (_playerWallet.PlayerValue < _price)
                return;
            _playerWallet.RemoveValue(_price);
            _levelDamage++;
            _levelProgressDamage.ShowLevel(_levelDamage);
        }
    }
}