using _Project.Screpts.Services;
using _Project.Scripts.SOConfigs;
using UnityEngine;
using Object = UnityEngine.Object;


namespace _Project.Scripts.GameUIElements.Shop
{
    public class CharacterInstance : IService
    {
        private CharactersConfig _characters;
        private Transform _spawnPoint;
        private PlayerCharacter _playerCharacterInstance;

        public PlayerCharacter PlayerCharacterInstance => _playerCharacterInstance;
        
        public CharacterInstance(CharactersConfig characters, Transform spawnPoint)
        {
            _characters = characters;
            _spawnPoint = spawnPoint;
        }

        public void InstanceCharacter()
        {
            if (_playerCharacterInstance != null)
                Object.Destroy(_playerCharacterInstance.gameObject);

            _playerCharacterInstance = Object.Instantiate(_characters.ActiveCharacter.CharacterPrefab);
            _playerCharacterInstance.transform.position = _spawnPoint.position;
        }

        public void Attack()
        {
            _playerCharacterInstance.Attack();
        }
    }
}