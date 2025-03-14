using _Project.Screpts.Services;
using _Project.Scripts.GameUIElements;
using _Project.Scripts.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class RespectView : MonoBehaviour, IRestart, IService
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _textRespectValue;
    [SerializeField] private Image _imageBoss;
    [SerializeField] private EnemyInstance _enemyInstance;

    private float _value;

    private void Start()
    {
        _slider.value = 0;
        _slider.maxValue = _enemyInstance.MaxInstance;
    }

    public void OnEnable() => _enemyInstance.OnBossInstance += BossInstance;

    public void ShowRespect()
    {
        var Random = new Random().Next(0, 1000);
        _value += Random;
        _textRespectValue.text = $"{_value}";
        _slider.value = _enemyInstance.InstanceCount;
    }

    public void BossInstance()
    {
        _imageBoss.gameObject.SetActive(true);
    }

    public void Restart()
    {
        _imageBoss.gameObject.SetActive(false);
        _slider.value = 0;
    }

    private void OnDisable() => _enemyInstance.OnBossInstance -= BossInstance;
}