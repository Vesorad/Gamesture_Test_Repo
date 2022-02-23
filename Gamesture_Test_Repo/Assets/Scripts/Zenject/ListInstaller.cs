using Assets.Scripts.List;
using UnityEngine;
using Zenject;


namespace Assets.Scripts.Zenject
{
    public class ListInstaller : MonoInstaller
    {
        [SerializeField] private readonly GameObject listPanel;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ListFacade>().FromComponentOnRoot().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<GameObject>().FromInstance(listPanel).AsSingle();
        }
    }
}
