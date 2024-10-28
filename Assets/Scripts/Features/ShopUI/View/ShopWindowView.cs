using UnityEngine;

public class ShopWindowView : MonoBehaviour
{
    [SerializeField] private Transform _transformComponent;
    
    public Transform ReturnTransformComponent()
    {
        return _transformComponent;
    }
}
