using System.Collections.Generic;
using _Project.Scripts.GameUI.Shop;
using TMPro;
using UnityEngine;

public class Closet : MonoBehaviour
{
    [SerializeField] private ShopItem[] _characters;
    [SerializeField] private TextMeshProUGUI _selectedCharacter;

    private int currentIndex = 0;
    private List<Vector2> positions = new(); // Храним позиции
    private float _moveDuration = 0.5f;
    private float _scaleFactor = 1.3f;

    private void Start()
    {
        // Считаем позиции
        for (int i = 0; i < _characters.Length; i++)
            positions.Add(_characters[i].RectTransform.anchoredPosition);
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

        int lastIndex = positions.Count - 1;
        Vector2 movedPosition = direction == 1 ? positions[lastIndex] : positions[0];
        positions.RemoveAt(direction == 1 ? lastIndex : 0);
        positions.Insert(direction == 1 ? 0 : positions.Count, movedPosition);

        for (int i = 0; i < _characters.Length; i++)
        {
            bool isCentral = i == 1;
            _characters[i].SetNewIndex(i, positions[i], isCentral);
        }
    }

    void UpdateSelection()
    {
        //_selectedText.text = characters[centerIndex].name; // Обновляем текст
    }
}