using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.Shop
{
    public class BackButtonView : MonoBehaviour
    {
        [SerializeField] private Button _returnBackButton;
        private UIService _uiService;

        [Inject]
        private void Construct(UIService uiService)
        {
            _uiService = uiService;
        }

        private void Awake()
        {
            _returnBackButton.onClick.AddListener(delegate { _uiService.HideShopWindow(); });
        }
    }
}
