using System.Collections.Generic;
using _Project.Scripts.EnemyGame;
using _Project.Scripts.Services;
using Services;
using UnityEngine;

namespace _Project.Scripts.EnemyPoolGame
{
    public class PoolObject<T> where T : MonoBehaviour, IPoolObject, IPauseItem, IDamageProvider
    {
        private List<T> _objects = new(10);
        private T _itemPrefab;
        private FreezeService _freezeService;
        private DamageService _damageService;

        public PoolObject(T itemPrefab)
        {
            _itemPrefab = itemPrefab;
            _freezeService = ServiceLocator.Instance.GetService<FreezeService>();
            _damageService = ServiceLocator.Instance.GetService<DamageService>();
        }

        public void Init()
        {
            for (int i = 0; i < 10; i++)
            {
                var instanceItem = Object.Instantiate(_itemPrefab);
                instanceItem.Active(false);
                _objects.Add(instanceItem);
                _freezeService.AddFreezeItem(instanceItem);
                _damageService.AddItem(instanceItem);
            }
        }


        public T GetItem()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                if (!_objects[i].IActive)
                {
                    _objects[i].Active(true);
                    return _objects[i];
                }
            }

            var instanceItem = Object.Instantiate(_itemPrefab);
            instanceItem.Active(true);
            _freezeService.AddFreezeItem(instanceItem);
            _damageService.AddItem(instanceItem);
            _objects.Add(instanceItem);
            return instanceItem;
        }

        public void Reset()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                _objects[i].Active(false);
                    
            }
        }
    }
}