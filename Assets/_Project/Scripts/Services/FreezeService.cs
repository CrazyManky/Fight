using System.Collections.Generic;
using _Project.Screpts.Services;

namespace _Project.Scripts.Services
{
    public class FreezeService : IService
    {
        private List<IPauseItem> _freezeItems = new();

        public void AddFreezeItem(IPauseItem item)
        {
            _freezeItems.Add(item);
        }

        public void FreezeExecute()
        {
            for (int i = _freezeItems.Count - 1; i >= 0; i--)
            {
                _freezeItems[i].PauseActive();
            }
        }

        public void FreezeDisable()
        {
            for (int i = _freezeItems.Count - 1; i >= 0; i--)
            {
                _freezeItems[i].PauseDisable();
            }
        }
    }

    public interface IPauseItem
    {
        public void PauseActive();
        public void PauseDisable();
    }
}