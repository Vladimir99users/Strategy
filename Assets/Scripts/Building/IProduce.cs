namespace Assets.Scripts.Building
{
    public interface IProduce<T> where T : Item
    {
        public T GetItem();
    }
}
