using UnityEngine;

namespace Assets.Scripts.Building.Item
{
    [CreateAssetMenu(fileName = "Gold", menuName = "Item/Gold")]
    public class Gold : ItemConfiguration
    {
        public void OnEnable()
        {
            Item.Type = ItemType.GoldItemName;
        }
    }
}