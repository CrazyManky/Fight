using System;
using _Project.Scripts.GameUI.Shop;
using _Project.Scripts.GameUIElements.Shop;
using _Project.Scripts.SOConfigs;
using Services;
using UnityEngine;

public class SelectedButton : MonoBehaviour
{
    [SerializeField] private ShopScreen _shopScreen;
    [SerializeField] private CharactersConfig _config;
    [SerializeField] private Closet _closet;

    private CharacterInstance _characterInstance;

    private void Start()
    {
        _characterInstance = ServiceLocator.Instance.GetService<CharacterInstance>();
    }

    public void SelectedItem()
    {
        var activeCharacter = _closet.GetCurrentCharacter();
        if (activeCharacter.IsBuy)
        {
            _config.SetDefaultCharacter(activeCharacter.NameItem);
            _shopScreen.Сlose();
            _characterInstance.InstanceCharacter();
        }
    }
}