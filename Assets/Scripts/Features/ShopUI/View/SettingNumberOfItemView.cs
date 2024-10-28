using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SettingNumberOfItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_InputField _inputField;

    private ShopWindowController _shopWindowController;
    private string _id;

    [Inject]
    private void Construct(ShopWindowController shopWindowController)
    {
        _shopWindowController = shopWindowController;
    }

    public void SetData(string id, Sprite icon)
    {
        _id = id;
        _icon.sprite = icon;
        
        _inputField.onValueChanged.AddListener(UpdateNumberOfItem);
    }
    
    private void UpdateNumberOfItem(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            bool parse = int.TryParse(text, out int intValue);
            
            if (parse)
            {
                if (intValue > 0 && intValue < 100)
                {
                    _shopWindowController.ShopItemsConfig[_id].NumberOfItems = intValue;
                }
                else
                {
                    _shopWindowController.ShopItemsConfig[_id].NumberOfItems = 0;
                    _inputField.text = "0";
                }
            }
        }
    }
}
