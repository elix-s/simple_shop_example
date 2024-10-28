using UnityEngine;

namespace Features.Shop
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Items/ItemData")]
    public class ItemData : ScriptableObject
    {
        [field: SerializeField] public string ItemId { get; set; }
        [field: SerializeField] public string ItemName { get; set; }
        [field: SerializeField] public Sprite ItemIcon { get; set; }
    }
}
