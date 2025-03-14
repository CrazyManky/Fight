using System.Collections;
using _Project.Scripts.GameUIElements;
using Services;
using UnityEngine;

namespace _Project.Scripts.Skills
{
    public class SpeedKick : AbilityButton
    {
        private DamageService _damageService;

        private void Start()
        {
            _damageService = ServiceLocator.Instance.GetService<DamageService>();
        }

        private IEnumerator Kick()
        {
            BuffActive = true;
            _damageService.SpeedDamage(30);
            var waitForEndOfFrame = new WaitForSeconds(Step);
            Slider.value = Delay;
            Slider.gameObject.SetActive(true);
            ImageButton.sprite = DelaySprite;

            while (Slider.value != 0)
            {
                Slider.value -= Step;
                yield return waitForEndOfFrame;
            }

            ImageButton.sprite = ReadySprite;
            Slider.gameObject.SetActive(false);
            Slider.value = Delay;
            BuffActive = false;
        }

        protected override void CoroutineRunner()
        {
            StartCoroutine(Kick());
        }
    }
}