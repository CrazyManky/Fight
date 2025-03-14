namespace _Project.Scripts.EnemyGame
{
    public interface IPoolObject
    {
        public bool IActive { get; }
        public void Active(bool value);
    }
}