using Assets.Scripts.Building.Item;

namespace Assets.Scripts.Service
{
    public interface IDataNotifier
    {
        public event System.Action<Item> IsItemChanged;
    }
}