using UnityEngine;

namespace Assets.Scripts.Building
{
    [CreateAssetMenu(fileName = "Apple", menuName = "Item/Apple")]
    public class Apple : ItemConfiguration
    {
        public void OnEnable()
        {
            Item.Type = ItemType.AppleItemName;
        }
    }
}