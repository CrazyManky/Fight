using System.Collections.Generic;
using _Project.Screpts.Services;
using _Project.Scripts.EnemyGame;
using _Project.Scripts.GameUIElements.Shop;
using _Project.Scripts.Skills;
using Services;
using UnityEngine;

namespace _Project.Scripts
{
    public class DamageService : IService
    {
        private List<IDamageProvider> _items = new();
        private CharacterInstance _characterInstance;

        public DamageService()
        {
            _characterInstance = ServiceLocator.Instance.GetService<CharacterInstance>();
        }

        public void AddItem(IDamageProvider damage)
        {
            _items.Add(damage);
        }

        public void SpeedDamage(int Damage)
        {
            if (_items.Count == 0) return;

            IDamageProvider nearestEnemy = null;
            float minDistance = float.MaxValue;
            Vector2 characterPosition = _characterInstance.PlayerCharacterInstance.transform.position;

            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i] is Enemy enemy && enemy.IActive)
                {
                    float distance = Vector2.Distance(characterPosition, enemy.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestEnemy = _items[i];
                    }
                }
            }

            nearestEnemy?.TakeDamage(Damage + Buffs.Damage);
        }

        public void ImpactDamage(int damage)
        {
            if (_items.Count == 0) return;

            for (int i = 0; i < _items.Count; i++)
                _items[i].TakeDamage(damage + Buffs.Damage);
        }
    }
}