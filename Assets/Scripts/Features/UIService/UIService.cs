using Common.AssetsSystem;
using Cysharp.Threading.Tasks;
using Features.Shop;
using UnityEngine;
using Zenject;

public class UIService
{
    private IAssetProvider _assetProvider;
    private IAssetUnloader _shopWindowUnloader;
    private DiContainer _container;

    private UIService(IAssetProvider assetProvider, IAssetUnloader shopWindowUnloader,
        DiContainer container)
    {
        _assetProvider = assetProvider;
        _shopWindowUnloader = shopWindowUnloader;
        _container = container;
    }

    public async UniTask ShowStartScreen()
    {
        var startScreen = await _assetProvider.GetAssetAsync<GameObject>("StartScreen");

        if (startScreen != null)
        {
            var prefab = _container.InstantiatePrefab(startScreen);
        }
    }

    public async UniTask<Transform> ShowShopWindow()
    {
        var shopWindow = await _assetProvider.GetAssetAsync<GameObject>("ShopWindow");
        _shopWindowUnloader.AddResource(shopWindow);

        var transform = new GameObject().transform;

        if (shopWindow != null)
        {
            var shopWindowView = _container.InstantiatePrefab(shopWindow).GetComponent<ShopWindowView>();
            transform = shopWindowView.ReturnTransformComponent();
            _shopWindowUnloader.AttachInstance(shopWindowView.gameObject);
        }

        return transform;
    }

    public async UniTask ShowItemsPanel(ShopUIData shopUIData, Transform parentTransform)
    {
        var itemsPanel = await _assetProvider.GetAssetAsync<GameObject>("ItemsPanel");
        _shopWindowUnloader.AddResource(itemsPanel);

        if (itemsPanel != null)
        {
            var itemsPanelView = _container.InstantiatePrefab(itemsPanel, parentTransform)
                .GetComponent<ItemsPanelView>();
            itemsPanelView.SetData(shopUIData);
        }
    }

    public void HideShopWindow()
    {
        _shopWindowUnloader.Dispose();
    }
}

