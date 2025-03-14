using System.Collections.Generic;
using _Project.Screpts.Services;

namespace _Project.Scripts.Services
{
    public class RestartService : IService
    {
        private List<IRestart> _list = new();

        public void AddRestartItem(IRestart item)
        {
            _list.Add(item);
        }

        public void Restart()
        {
            foreach (var restart in _list)
                restart.Restart();
        }
    }
}