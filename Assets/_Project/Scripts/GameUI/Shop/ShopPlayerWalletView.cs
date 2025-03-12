using _Project.Scripts.SOConfigs;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.GameUI.Shop
{
    public class ShopPlayerWalletView : MonoBehaviour
    {
        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private TextMeshProUGUI _textValue;

        private void OnEnable() => _playerWallet.OnChange += SetValue;

        private void Start() => SetValue();

        private void SetValue() => _textValue.text = $"{_playerWallet.PlayerValue}";

        private void OnDisable() => _playerWallet.OnChange -= SetValue;
    }
}