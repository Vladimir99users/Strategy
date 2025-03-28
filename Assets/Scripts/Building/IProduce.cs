namespace Assets.Scripts.Building
{
    public interface IProduce<T> where T : Item.Item
    {
        public T GetItem();
    }
}
