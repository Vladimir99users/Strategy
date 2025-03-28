using Assets.Scripts.Building.Item;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public class DataService : MonoBehaviour, IDataNotifier
    {
        public event Action<Item> IsItemChanged;
        private Dictionary<string, Item> Items = new();
        private IDataCollection dataCollector;
        public void Initialize(IEnumerable<ItemConfiguration> items, IDataCollection dataCollector)
        {
            FieldItems(items);
            this.dataCollector = dataCollector;
            this.dataCollector.OnCollectItem += CollectItem;
        }
        private void OnDisable()
        {
            dataCollector.OnCollectItem -= CollectItem;
        }

        private void FieldItems(IEnumerable<ItemConfiguration> items)
        {
            foreach (var itemConfiguration in items)
            {
                if (Items.ContainsKey(itemConfiguration.Item.Type))
                {
                    Debug.LogError("Is Equals item, he is not adding to system");
                    return;
                }

                var item = new Item
                {
                    Type = itemConfiguration.Item.Type,
                    Amount = itemConfiguration.Item.Amount,
                };

                Items.Add(item.Type, item);
            }
        }

        private void CollectItem(Item obj)
        {
            if (!Items.ContainsKey(obj.Type))
                return;

            Items[obj.Type].Amount += obj.Amount;
            IsItemChanged?.Invoke(Items[obj.Type]);
        }

    }
}
