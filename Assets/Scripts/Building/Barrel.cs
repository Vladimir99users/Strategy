using UnityEngine;

namespace Assets.Scripts.Building
{
    [CreateAssetMenu(fileName = "Barrel", menuName = "Item/Barrel")]
    public class Barrel : ItemConfiguration
    {
        public void OnEnable()
        {
            Item.Type = ItemType.BarrelItemName;
        }
    }
}