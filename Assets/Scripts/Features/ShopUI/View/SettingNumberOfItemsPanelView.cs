using UnityEngine;
using Zenject;

public class SettingNumberOfItemsPanelView : MonoBehaviour
{
    [SerializeField] private GameObject _settingNumberPrefab;
    [SerializeField] private Transform _setttingNumbersPanel;

    private DiContainer _container;
    private ShopWindowController _shopWindowController;

    [Inject]
    private void Construct(DiContainer container, ShopWindowController shopWindowController)
    {
        _container = container;
        _shopWindowController = shopWindowController;
    }

    private void Awake()
    {
        InstantiateItems();
    }

    private void InstantiateItems()
    {
        _shopWindowController.UpdateShopItems();
        
        var items = _shopWindowController.ShopItemsConfig;

        foreach (var i in items)
        {
            var prefabView =_container.InstantiatePrefab(_settingNumberPrefab, _setttingNumbersPanel).GetComponent<SettingNumberOfItemView>();
            prefabView.SetData(i.Value.ItemId, i.Value.ItemIcon);
        }
    }
}
