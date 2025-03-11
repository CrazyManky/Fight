using UnityEngine;

namespace _Project.Scripts.GameUI.Shop
{
    public class ShopScreen : MonoBehaviour
    {
        [field: SerializeField] private levelProgress _levelProgressSpeed;
        [field: SerializeField] private levelProgress _levelProgressDamage;

        private int _levelSpeed = 0;
        private int _levelDamage = 0;

        public void PurchaseSpeedBonus()
        {
            _levelSpeed++;
            _levelProgressSpeed.ShowLevel(_levelSpeed);
        }

        public void PurchaseDamageBonus()
        {
            _levelDamage++;
            _levelProgressDamage.ShowLevel(_levelDamage);
        }
    }
}