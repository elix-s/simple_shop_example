using UnityEngine;

namespace Features.Shop
{
    public class ShopWindowView : MonoBehaviour
    {
        [SerializeField] private Transform _transformComponent;

        public Transform ReturnTransformComponent()
        {
            return _transformComponent;
        }
    }
}
