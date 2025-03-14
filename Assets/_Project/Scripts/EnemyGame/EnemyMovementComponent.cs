using System;
using UnityEngine;

namespace _Project.Scripts.EnemyGame
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMovementComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        private Enemy _enemy;
        private Vector2 _moveDirection = new(-1, 0);

        private void Awake() => _enemy = GetComponent<Enemy>();

        public void FixedUpdate() => Move();

        public void Move()
        {
            if (_enemy.Pause)
            {
                _rigidbody.velocity = Vector2.zero;
                return;
            }

            _rigidbody.velocity = _moveDirection * _enemy.Speed;
        }
    }
}