using System;
using _Project.Scripts.Services;
using _Project.Scripts.SOConfigs;
using Services;
using UnityEngine;


namespace _Project.Scripts.EnemyGame
{
    public class Enemy : MonoBehaviour, IPoolObject, IDamageProvider, IPauseItem
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] private float _speed;
        [SerializeField] private PlayerWallet _playerWallet;

        private int _maxHealth = 100;
        private int _price = 100;
        private RespectView _respectView;
        public bool IActive { get; private set; } = false;
        public bool Pause { get; private set; }

        public Transform Transform
        {
            get { return transform; }
        }

        public float Speed => _speed;

        public event Action OnEnterCharacter;
        public event Action<int, int> OnTakeDamage;
        public event Action OnDead;
        public event Action OnPause;

        public void OnEnable()
        {
            if (_respectView == null)
                return;
            OnDead += _respectView.ShowRespect;
        }

        private void Start()
        {
            _respectView = ServiceLocator.Instance.GetService<RespectView>();
            OnDead += _respectView.ShowRespect;
        }


        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerCharacter>(out var component))
            {
                OnEnterCharacter?.Invoke();
            }
        }

        public void TakeDamage(int damage)
        {
            if (!IActive)
                return;

            Health = Math.Max(0, Health - damage);
            OnTakeDamage?.Invoke(Health, _maxHealth);

            if (Health == 0)
                Dead();
        }

        public void Dead()
        {
            OnDead?.Invoke();
            _playerWallet.AddValue(_price);
            Active(false);
        }

        public void Active(bool value)
        {
            if (value)
            {
                Health = _maxHealth;
                OnTakeDamage?.Invoke(Health, _maxHealth);
            }

            IActive = value;
            gameObject.SetActive(IActive);
        }

        public void PauseActive()
        {
            Pause = true;
            OnPause?.Invoke();
        }

        public void PauseDisable()
        {
            Pause = false;
            OnPause?.Invoke();
        }

        public void OnDisable()
        {
            if (_respectView != null)
            {
                OnDead += _respectView.ShowRespect;
                return;
            }
        }
    }
}