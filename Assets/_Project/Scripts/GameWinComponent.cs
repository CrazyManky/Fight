using System;
using _Project.Scripts.EnemyGame;
using _Project.Scripts.GameUIElements;
using Services;
using UnityEngine;

namespace _Project.Scripts
{
    [RequireComponent(typeof(Enemy))]
    public class GameWinComponent : MonoBehaviour
    {
        private Enemy _enemy;
        private GameUIScreen _gameUIScreen;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _gameUIScreen = ServiceLocator.Instance.GetService<GameUIScreen>();
        }

        private void OnEnable() => _enemy.OnDead += CheckWin;

        public void CheckWin()
        {
            if (_enemy.Health == 0)
                _gameUIScreen.ShowWinScreen();
        }

        private void OnDisable() => _enemy.OnDead -= CheckWin;
    }
}