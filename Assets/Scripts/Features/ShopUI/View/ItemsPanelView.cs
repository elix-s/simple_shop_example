using System;
using Common.AssetsSystem;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using Zenject;

namespace Features.Shop
{
    public class ItemsPanelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Image _mainIcon;
        [SerializeField] private Transform _itemsPanel;
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private GameObject _discountIcon;
        [SerializeField] private TextMeshProUGUI _discountText;
        [SerializeField] private Button _buyButton;

        private IAssetProvider _assetProvider;
        private ShopWindowController _shopWindowController;
        private DiContainer _container;

        private float _price;

        [Inject]
        private void Construct(ShopWindowController shopWindowController, DiContainer diContainer)
        {
            _shopWindowController = shopWindowController;
            _container = diContainer;
        }

        private void Awake()
        {
            _buyButton.onClick.AddListener(delegate { Debug.Log($"Item purchased for ${_price}"); });
        }

        public async void SetData(ShopUIData data)
        {
            _price = data.Price;
            _titleText.text = data.TitleText;
            _descriptionText.text = data.DescriptionText;

            if (_shopWindowController.ShopItemsConfig.Count == 0)
                _shopWindowController.UpdateShopItems();

            foreach (var item in data.CreatedItems)
            {
                if (_shopWindowController.ShopItemsConfig.ContainsKey(item))
                {
                    var i = _container.InstantiatePrefab(_itemPrefab, _itemsPanel).GetComponent<ItemPrefabView>();
                    i.SetData(_shopWindowController.ShopItemsConfig[item].ItemIcon,
                        _shopWindowController.ShopItemsConfig[item].NumberOfItems);
                }
            }

            if (data.Discount <= 0)
            {
                _discountIcon.SetActive(false);
                _priceText.text = "$" + data.Price;
            }
            else
            {
                _discountIcon.SetActive(true);

                var discountValue = 0;

                if (data.Discount <= 100)
                {
                    discountValue = data.Discount;
                }
                else
                {
                    discountValue = 100;
                }

                var price = data.Price - ((discountValue / 100.0f) * data.Price);
                _priceText.text = "<s>" + "$" + data.Price + "</s>" + " " + "<color=#FF0000>" + "$" +
                                  Math.Round(price, 2) + "</color>";
                _discountText.text = discountValue + "%";
            }

            if (data.MainIconAddress != string.Empty)
            {
                AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(data.MainIconAddress);
                await handle.Task;

                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    _mainIcon.sprite = handle.Result;
                }
            }
        }
    }
}
