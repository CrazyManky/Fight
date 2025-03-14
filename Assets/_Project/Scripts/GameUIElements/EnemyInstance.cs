using System;
using System.Collections;
using _Project.Scripts.EnemyGame;
using _Project.Scripts.EnemyPoolGame;
using _Project.Scripts.Services;
using Services;
using UnityEngine;
using Random = System.Random;

namespace _Project.Scripts.GameUIElements
{
    public class EnemyInstance : MonoBehaviour, IPauseItem, IRestart
    {
        [SerializeField] private Transform[] _transforms;
        [SerializeField] private Enemy _enemyPrefabOne;
        [SerializeField] private Enemy _enemyPrefabTwo;
        [SerializeField] private Enemy _enemyPrefabFree;
        [SerializeField] private Enemy _enemyPrefabFour;
        [SerializeField] private Enemy _Boss;

        private PoolObject<Enemy>[] _pools;
        private PoolObject<Enemy> _boss;
        private FreezeService _freezeService;
        private DamageService _damageService;
        private GameUIScreen _gameUIScreen;

        public int InstanceCount { get; private set; } = 0;
        public int MaxInstance { get; private set; } = 20;
        private Vector2 _lastEnemyPosition;

        public event Action OnBossInstance;

        private Coroutine _activeCoroutine;

        private void Start()
        {
            InitPools();
            StartSpawning();
            _freezeService = ServiceLocator.Instance.GetService<FreezeService>();
            _damageService = ServiceLocator.Instance.GetService<DamageService>();
        }

        private void InitPools()
        {
            _boss = new PoolObject<Enemy>(_Boss);
            _boss.Init();
            _pools = new[]
            {
                new PoolObject<Enemy>(_enemyPrefabOne),
                new PoolObject<Enemy>(_enemyPrefabTwo),
                new PoolObject<Enemy>(_enemyPrefabFree),
                new PoolObject<Enemy>(_enemyPrefabFour),
            };
            foreach (var pool in _pools)
                pool.Init();
        }

        private IEnumerator SpawnEnemy()
        {
            var waitForSecondsRealTime = new WaitForSecondsRealtime(3f);
            var waitForSecondsRealTimeBoss = new WaitForSecondsRealtime(1f);
            while (InstanceCount < MaxInstance)
            {
                Transform spawnPoint = _transforms[new Random().Next(0, _transforms.Length)];
                if (Vector2.Distance(spawnPoint.position, _lastEnemyPosition) >= 0.1f)
                {
                    var enemy = _pools[new Random().Next(0, _pools.Length)];
                    Enemy enemyInstance = enemy.GetItem();
                    enemyInstance.Active(true);
                    enemyInstance.transform.position = spawnPoint.position;

                    _lastEnemyPosition = spawnPoint.position;
                    InstanceCount++;
                }

                yield return waitForSecondsRealTime;

                if (InstanceCount == MaxInstance)
                {
                    OnBossInstance?.Invoke();
                    yield return waitForSecondsRealTimeBoss;
                    BossInstance();
                }
            }
        }

        public void StartSpawning()
        {
            if (_activeCoroutine == null)
            {
                _activeCoroutine = StartCoroutine(SpawnEnemy());
            }
        }

        public void StopSpawning()
        {
            if (_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
                _activeCoroutine = null;
            }
        }

        public void BossInstance()
        {
            Transform spawnPoint = _transforms[new Random().Next(0, _transforms.Length)];
            var instance = _boss.GetItem();
            instance.transform.position = spawnPoint.position;
            OnBossInstance?.Invoke();
        }


        public void PauseActive()
        {
            StopSpawning();
        }

        public void PauseDisable()
        {
            StartSpawning();
        }

        public void Restart()
        {
            StopSpawning();
            InstanceCount = 0;
            StartSpawning();
            foreach (var pool in _pools)
                pool.Reset();
        }
    }
}