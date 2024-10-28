using Common.AssetsSystem;
using Zenject;
using Features.Shop;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IAssetProvider>().To<AssetProvider>().AsTransient();
        Container.Bind<IAssetUnloader>().To<AssetUnloader>().AsTransient();
        Container.Bind<UIService>().AsSingle().NonLazy();
        Container.Bind<GameSessionService>().AsSingle().NonLazy();
        Container.Bind<ShopWindowController>().AsSingle().NonLazy();
    }
}
