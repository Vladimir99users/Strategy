using UnityEngine;

namespace Assets.Scripts.Building
{
    public abstract class ItemConfiguration : ScriptableObject
    {
        public int TimeToGeneration;
        public Item Item;
        public UnityEngine.Sprite Sprite;
    }
}