using Assets.Scripts.Building.Item;

namespace Assets.Scripts.Service
{
    public interface IDataCollection
    {
        public event System.Action<Item> OnCollectItem;
    }
}