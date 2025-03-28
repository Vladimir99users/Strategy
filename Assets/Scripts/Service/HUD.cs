using Assets.Scripts.Building.Item;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.Service
{
    public class HUD : Screen
    {
        [SerializeField] private Button openButton;
        [SerializeField] private ItemUI prefab;
        [SerializeField] private ResourceHUD parenTransform;

        private Dictionary<string, ItemUI> UIItems = new();
        private IDataNotifier dataService;
        public void Initialize(IDataNotifier dataService, IEnumerable<ItemConfiguration> items)
        {
            CreateUIItem(items);
            this.dataService = dataService;
            this.dataService.IsItemChanged += Refresh;
            openButton.onClick.AddListener(OpenResourceHUD);
        }

        private void OnDisable()
        {
            dataService.IsItemChanged -= Refresh;
        }

        private void CreateUIItem(IEnumerable<ItemConfiguration> items)
        {
            foreach (var item in items)
            {
                var itemUI = Instantiate(prefab, parenTransform.transform);
                itemUI.Initialize(item.Sprite, item.Item.Amount);
                UIItems.Add(item.Item.Type, itemUI);
            }
        }
        private void OpenResourceHUD()
        {
            if (parenTransform.IsOpen)
                parenTransform.Close();
            else
                parenTransform.Open();
        }

        private void Refresh(Item obj)
        {
            if (!UIItems.ContainsKey(obj.Type))
                return;

            var uiItem = UIItems[obj.Type];
            uiItem.Refresh(obj.Amount);
        }

    }
}
