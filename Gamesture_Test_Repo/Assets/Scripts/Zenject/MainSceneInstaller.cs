using Assets.Scripts.List;
using Zenject;

namespace Assets.Scripts.Zenject
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ListManager>().AsSingle();
        }
    }
}
