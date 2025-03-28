using UnityEngine;

namespace Assets.Scripts.Building.Item
{
    [CreateAssetMenu(fileName = "Banana", menuName = "Item/Banana")]
    public class Banana : ItemConfiguration
    {
        public void OnEnable()
        {
            Item.Type = ItemType.BananaItemName;
        }
    }
}