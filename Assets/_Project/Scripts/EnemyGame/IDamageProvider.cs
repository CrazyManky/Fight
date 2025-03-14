using UnityEngine;

namespace _Project.Scripts.EnemyGame
{
    public interface IDamageProvider
    {
        public Transform Transform { get; }
        public void TakeDamage(int damage);
    }
}