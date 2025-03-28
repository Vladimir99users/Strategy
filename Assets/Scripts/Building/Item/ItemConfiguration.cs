using UnityEngine;

namespace Assets.Scripts.Building.Item
{
    public abstract class ItemConfiguration : ScriptableObject
    {
        public int TimeToGeneration;
        public Item Item;
        public UnityEngine.Sprite Sprite;
    }
}