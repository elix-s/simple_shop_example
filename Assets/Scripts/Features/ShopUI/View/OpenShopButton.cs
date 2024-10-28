using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OpenShopButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private UIService _uiService;
    private ShopWindowController _shopWindowController;

    [Inject]
    private void Construct(UIService uiService, ShopWindowController shopWindowController)
    {
        _uiService = uiService;
        _shopWindowController = shopWindowController;
    }

    private void Awake()
    {
        _button.onClick.AddListener(ShowShop);
    }

    private async void ShowShop()
    {
        var shopPanel = await _uiService.ShowShopWindow();
        
        var itemsList = _shopWindowController.CreateItemsList("coal", "grass", "mineral", 
            "stone", "rope", "tree");

        if (itemsList != null)
        {
            var title = "Ресурсы для стройки";
            var description = "Покори небеса, построй плот своей мечты";
            var price = 2.99f;
            var discount = 50;
            var mainIconAddress = "mainIcon";

            var shopUIData = new ShopUIData(title, description, itemsList, price, discount, mainIconAddress);
            _uiService.ShowItemsPanel(shopUIData, shopPanel).Forget();
        }

        var itemsList2 = _shopWindowController.CreateItemsList("coal", "grass", "mineral");

        if (itemsList2 != null)
        {
            var title = "Набор начинающего строителя";
            var description = "Поможет установить на плот все необходимые постройки";
            var price = 3.99f;
            var discount = 0;
            var mainIconAddress = "mainIcon";

            var shopUIData2 = new ShopUIData(title, description, itemsList2, price, discount, mainIconAddress);
            _uiService.ShowItemsPanel(shopUIData2, shopPanel).Forget();
        }
    }
}
