using _Project.Scripts.SOConfigs;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.GameUI.Shop
{
    public class ShopItem : MonoBehaviour
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }
        [field: SerializeField] public string NameItem { get; private set; }
        [SerializeField] private CharactersConfig _config;
        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private Image _imageLock;
        [SerializeField] private Image _itemView;
        [SerializeField] private Button _buyButton;
        [SerializeField] private TextMeshProUGUI _priceValue;

        private Vector2 _targetPosition;
        private float _targetScale;
        private int _price;
        public int ItemIndex { get; private set; }
        public bool IsBuy { get; private set; }


        private void OnEnable() => _buyButton.onClick.AddListener(BuyItem);

        public void SetData(int index, Sprite sprite, bool isUnlock, string nameItem, int Price)
        {
            UnlockElement(isUnlock);
            ItemIndex = index;
            _itemView.sprite = sprite;
            NameItem = nameItem;
            _priceValue.text = $"{Price}";
            _price = Price;
        }

        private void UnlockElement(bool isUnlock)
        {
            IsBuy = isUnlock;
            if (isUnlock)
            {
                _imageLock.gameObject.SetActive(false);
                _buyButton.gameObject.SetActive(false);
            }
        }

        public void SetNewIndex(int index, Vector2 position, bool isCentral)
        {
            ItemIndex = index;
            _targetPosition = position;
            _targetScale = isCentral ? 1.3f : 1f;
            ApplyAnimations();
        }

        private void ApplyAnimations()
        {
            RectTransform.DOAnchorPos(_targetPosition, 1f)
                .OnComplete(() => { RectTransform.DOScale(_targetScale, 1f); }).SetEase(Ease.OutQuad);
        }

        public void BuyItem()
        {
            if (_playerWallet.PlayerValue >= _price)
            {
                _config.SetCharacter(NameItem);
                UnlockElement(true);
            }
        }

        private void OnDisable() => _buyButton.onClick.RemoveListener(BuyItem);
    }
}