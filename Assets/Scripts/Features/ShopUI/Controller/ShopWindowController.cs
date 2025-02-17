using System.Collections.Generic;
using UnityEngine;

namespace Features.Shop
{
    public class ShopWindowController
    {
        /// <summary>
        /// Слварь для хранения всех предметов.
        /// </summary>
        public Dictionary<string, ItemModel> ShopItemsConfig = new Dictionary<string, ItemModel>();

        /// <summary>
        /// Получение актуально списка предметов из конфигов и парсинг его в словарь.
        /// </summary>
        public void UpdateShopItems()
        {
            ShopItemsConfig = ParseItemsToDictionary();
        }

        private Dictionary<string, ItemModel> ParseItemsToDictionary()
        {
            var itemDictionary = new Dictionary<string, ItemModel>();

            var itemDataArray = LoadAllItemData();

            foreach (var itemData in itemDataArray)
            {
                var itemModel = new ItemModel(
                    itemData.ItemId,
                    itemData.ItemName,
                    itemData.ItemIcon
                );

                if (!itemDictionary.ContainsKey(itemData.ItemName))
                {
                    itemDictionary.Add(itemData.ItemId, itemModel);
                }
                else
                {
                    Debug.LogWarning($"Item with name {itemData.ItemName} already exists in the dictionary.");
                }
            }

            return itemDictionary;
        }
        
        /// <summary>
        /// Создание списка предметов для передачи в окно. Можно создать от 3х до 6.
        /// </summary>
        public List<string> CreateItemsList(params string[] values)
        {
            if (values.Length < 3 || values.Length > 6)
            {
                Debug.Log(("Method accepts only between 3 and 6 parameters."));
                return null;
            }

            return new List<string>(values);
        }

        private ItemData[] LoadAllItemData()
        {
            var items = Resources.LoadAll<ItemData>("");

            if (items.Length == 0)
            {
                Debug.LogWarning("No ItemData found in Resources.");
            }
            else
            {
                Debug.Log($"{items.Length} ItemData configurations loaded.");
            }

            return items;
        }
    }
}
