using System.Collections;
using _Project.Scripts.GameUIElements;
using _Project.Scripts.Services;
using Services;
using UnityEngine;

namespace _Project.Scripts.Skills
{
    public class Freeze : AbilityButton
    {
        private FreezeService _freeze;

        private void Start()
        {
            _freeze = ServiceLocator.Instance.GetService<FreezeService>();
        }

        private IEnumerator BuffActive()
        {
            _freeze.FreezeExecute();
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
            _freeze.FreezeDisable();
        }

        protected override void CoroutineRunner()
        {
            StartCoroutine(BuffActive());
        }
    }
}