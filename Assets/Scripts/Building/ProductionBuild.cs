using Assets.Scripts.Building.Item;
using Assets.Scripts.Service;
using UnityEngine;

namespace Assets.Scripts.Building
{
    public class ProductionBuild : Building, IProduce<Item.Item>
    {
        [SerializeField] private ItemConfiguration _itemConfiguration;
        [SerializeField] private ProductionBuildUi productionBuildUi;

        private int timeStep = 0;
        private Item.Item item;
        private ISecondElapsedNotifier secondElapsedNotifier;
        public void Initialize(ISecondElapsedNotifier secondElapsedNotifier)
        {
            productionBuildUi.Initialize(_itemConfiguration.TimeToGeneration, _itemConfiguration.Sprite, _itemConfiguration.Item.Type);
            this.secondElapsedNotifier = secondElapsedNotifier;
            this.secondElapsedNotifier.OnSecondEnd += GenerateItem;
            item = new Item.Item();
            item.Type = _itemConfiguration.Item.Type;
            item.Amount = _itemConfiguration.Item.Amount;
        }

        private void OnDisable()
        {
            secondElapsedNotifier.OnSecondEnd -= GenerateItem;
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
        public Item.Item GetItem()
        {
            Item.Item sendItem = new Item.Item
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
