using _Project.Scripts.EnemyGame;
using _Project.Scripts.GameUIElements;
using _Project.Scripts.Skills;
using UnityEngine;

namespace _Project.Scripts
{
    public class LoseZone : MonoBehaviour
    {
        [SerializeField] private GameUIScreen _gameUIScreen;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                if (NoGameLose.Acitve)
                {
                    enemy.Active(false);
                    return;
                }

                _gameUIScreen.ShowLoseScreen();
            }
        }
    }
}