using System;
using UnityEngine;

namespace _Project.Scripts.EnemyGame
{
    [RequireComponent(typeof(Animator), typeof(Enemy))]
    public class EnemyAnimatorComponent : MonoBehaviour
    {
        private Animator _animator;
        private Enemy _enemy;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _enemy = GetComponent<Enemy>();
        }

        public void Update()
        {
            Stop();
        }

        public void Stop()
        {
            _animator.enabled = !_enemy.Pause;
        }
    }
}