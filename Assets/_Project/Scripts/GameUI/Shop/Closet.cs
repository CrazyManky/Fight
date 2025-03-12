using System.Collections.Generic;
using _Project.Scripts.GameUI.Shop;
using TMPro;
using UnityEngine;

public class Closet : MonoBehaviour
{
    [SerializeField] private ShopItem[] _characters;
    [SerializeField] private TextMeshProUGUI _selectedCharacter;

    private int _currentIndex = 0;
    private List<Vector2> _positions = new(); // Храним позиции
    private float _moveDuration = 0.5f;
    private float _scaleFactor = 1.3f;

    private void Start()
    {
        // Считаем позиции
        for (int i = 0; i < _characters.Length; i++)
            _positions.Add(_characters[i].RectTransform.anchoredPosition);
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

        ShopItem temp = direction == 1 ? _characters[_characters.Length - 1] : _characters[0];
        if (direction == 1)
        {
            for (int i = _characters.Length - 1; i > 0; i--)
                _characters[i] = _characters[i - 1];

            _characters[0] = temp;
        }
        else
        {
            for (int i = 0; i < _characters.Length - 1; i++)
                _characters[i] = _characters[i + 1];

            _characters[_characters.Length - 1] = temp;
        }

        for (int i = 0; i < _characters.Length; i++)
        {
            bool isCentral = i == 1;
            _characters[i].SetNewIndex(i, _positions[i], isCentral);
            if (isCentral)
                UpdateSelection(_characters[i].NameItem);
        }
    }

    private void UpdateSelection(string value) => _selectedCharacter.text = $"{value}";
}