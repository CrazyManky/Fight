using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.SOConfigs
{
    [CreateAssetMenu(fileName = "CharactersConfig", menuName = "Characters")]
    public class CharactersConfig : ScriptableObject
    {
        [SerializeField] private List<CharacterItem> _characters = new();

        public CharacterItem ActiveCharacter;

        private void Awake()
        {
            _characters.ForEach((item) => { item.Loading(); });
            ActiveCharacter = _characters[0];
        }

        public void SetCharacter(string Name)
        {
            _characters.ForEach((item) =>
            {
                if (item.NameItem == Name)
                {
                    item.Unlock();
                    ActiveCharacter = item;
                }
            });
        }

        public void SetDefaultCharacter(string nameItem)
        {
            _characters.ForEach((item) =>
            {
                if (item.NameItem == nameItem && item.IsBuy)
                {
                    ActiveCharacter = item;
                }
            });
        }

        public CharacterItem GetItems(int index)
        {
            return _characters[index];
        }
    }

    [Serializable]
    public class CharacterItem
    {
        public int ID;
        public string NameItem;
        public PlayerCharacter CharacterPrefab;
        public Sprite SpriteCharacter;
        public bool IsBuy = false;
        public int Price;

        public void Unlock()
        {
            PlayerPrefs.SetInt($"Item{ID}", 1);
            IsBuy = true;
        }

        public void Loading()
        {
            var value = PlayerPrefs.GetInt($"Item{ID}", 0);
            if (value == 1)
                IsBuy = true;
            else
                IsBuy = false;
        }
    }
}