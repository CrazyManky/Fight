using System.Collections.Generic;
using _Project.Scripts.SOConfigs;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.GameUI.Shop
{
    public class Closet : MonoBehaviour
    {
        [SerializeField] private CharactersConfig _characterConfig;
        [SerializeField] private List<ShopItem> _characters;
        [SerializeField] private TextMeshProUGUI _selectedCharacter;

        private int _currentIndex = 0;
        private List<Vector2> _positions = new();
        private float _moveDuration = 0.5f;
        private float _scaleFactor = 1.3f;

        private void Start()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                var character = _characterConfig.GetItems(i);
                _positions.Add(_characters[i].RectTransform.anchoredPosition);
                _characters[i].SetData(i, character.SpriteCharacter, character.IsBuy, character.NameItem,
                    character.Price);
            }

            MoveLeft();
        }

        public void MoveLeft()
        {
            MoveCarousel(-1);
        }

        public void MoveRight()
        {
            MoveCarousel(1);
        }

        void MoveCarousel(int direction)
        {
            if (direction != 1 && direction != -1) return;

            ShopItem temp = direction == 1 ? _characters[_characters.Count - 1] : _characters[0];
            if (direction == 1)
            {
                for (int i = _characters.Count - 1; i > 0; i--)
                    _characters[i] = _characters[i - 1];

                _characters[0] = temp;
            }
            else
            {
                for (int i = 0; i < _characters.Count - 1; i++)
                    _characters[i] = _characters[i + 1];

                _characters[_characters.Count - 1] = temp;
            }

            for (int i = 0; i < _characters.Count; i++)
            {
                bool isCentral = i == 1;
                _characters[i].SetNewIndex(i, _positions[i], isCentral);
                if (isCentral)
                    UpdateSelection(_characters[i].NameItem);
            }
        }
        
        public ShopItem GetCurrentCharacter()
        {
            return _characters[1];
        }

        private void UpdateSelection(string value) => _selectedCharacter.text = $"{value}";
    }
}