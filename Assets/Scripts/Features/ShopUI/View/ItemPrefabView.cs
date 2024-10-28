using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Shop
{
    public class ItemPrefabView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _counter;

        public void SetData(Sprite icon, int counter)
        {
            _icon.sprite = icon;
            _counter.text = counter.ToString();
        }
    }
}
