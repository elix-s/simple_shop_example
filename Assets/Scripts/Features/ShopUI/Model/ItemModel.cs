using UnityEngine;

namespace Features.Shop
{
    public class ItemModel
    {
        public string ItemId { get; }
        public string ItemName { get; }
        public Sprite ItemIcon { get; }
        public int NumberOfItems { get; set; }
        private int _defaultValue = 10;

        public ItemModel(string itemId, string itemName, Sprite itemIcon)
        {
            ItemId = itemId;
            ItemName = itemName;
            ItemIcon = itemIcon;
            NumberOfItems = _defaultValue;
        }
    }
}