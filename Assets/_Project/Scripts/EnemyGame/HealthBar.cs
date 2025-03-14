using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.EnemyGame
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Enemy _enemy;

        public void OnEnable() => _enemy.OnTakeDamage += ViewValue;

        public void ViewValue(int health, int maxHealth)
        {
            _slider.value = (float)health / maxHealth;
        }

        public void OnDisable() => _enemy.OnTakeDamage -= ViewValue;
    }
}