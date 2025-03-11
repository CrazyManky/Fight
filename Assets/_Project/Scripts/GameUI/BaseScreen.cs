using _Project.Scripts.Audio;
using Services;
using UnityEngine;

namespace _Project.Scripts.GameUI
{
    public abstract class BaseScreen : MonoBehaviour
    {
        protected AudioManager AudioManager;

        public virtual void Init()
        {
            //Dialog = ServiceLocator.Instance.GetService<DialogLauncher>();
            AudioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public virtual void Сlose() => Destroy(gameObject);
    }
}