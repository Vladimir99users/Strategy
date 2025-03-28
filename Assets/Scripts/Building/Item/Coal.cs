using UnityEngine;

namespace Assets.Scripts.Building.Item
{
    [CreateAssetMenu(fileName = "Coal", menuName = "Item/Coal")]
    public class Coal : ItemConfiguration
    {
        public void OnEnable()
        {
            Item.Type = ItemType.CoalItemName;
        }
    }
}