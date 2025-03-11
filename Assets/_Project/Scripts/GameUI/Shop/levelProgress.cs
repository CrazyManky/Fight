using System;
using System.Collections.Generic;
using _Project.Scripts.GameUI.Shop;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.GameUI.Shop
{
    [Serializable]
    public class levelProgress
    {
        [SerializeField] private Image[] _images;
        [SerializeField] private Sprite _active;
        [SerializeField] private Sprite _disable;
        
        
        public void ShowLevel(int level)
        {
            if (level > _images.Length)
                return;
            for (int i = 0; i <= level; i++)
            {
                if (i <= level - 1)
                    _images[i].sprite = _active;
            }
        }
    }
}