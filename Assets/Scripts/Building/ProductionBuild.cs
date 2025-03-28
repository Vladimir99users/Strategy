using Assets.Scripts.Service;
using UnityEngine;

namespace Assets.Scripts.Building
{
    public class ProductionBuild : Building, IProduce<Item>
    {
        [SerializeField] private ItemConfiguration _itemConfiguration;
        [SerializeField] private ProductionBuildUi productionBuildUi;

        private int timeStep = 0;
        private Item item;
        public void Initialize(ISecondElapsedNotifier secondElapsedNotifier)
        {
            productionBuildUi.Initialize(_itemConfiguration.TimeToGeneration, _itemConfiguration.Sprite, _itemConfiguration.Item.Type);
            secondElapsedNotifier.OnSecondEnd += GenerateItem;
            item = new Item();
            item.Type = _itemConfiguration.Item.Type;
            item.Amount = _itemConfiguration.Item.Amount;
        }

        private void GenerateItem()
        {
            timeStep += 1;
            if (timeStep == _itemConfiguration.TimeToGeneration)
            {
                item.Amount += 1;
                timeStep = 0;
            }
            productionBuildUi.Refresh(timeStep, item.Amount);
        }
        public Item GetItem()
        {
            Item sendItem = new Item
            {
                Amount = item.Amount,
                Type = item.Type,
            };
            item.Amount = 0;
            productionBuildUi.Refresh(timeStep, item.Amount);
            return sendItem;
        }
    }
}
