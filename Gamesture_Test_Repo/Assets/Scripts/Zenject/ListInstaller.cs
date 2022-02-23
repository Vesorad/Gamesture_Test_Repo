using Assets.Scripts.List;
using Assets.Scripts.Segment;
using UnityEngine;
using Zenject;


namespace Assets.Scripts.Zenject
{
    public class ListInstaller : MonoInstaller
    {
        [SerializeField] private RectTransform listPanel;
        [SerializeField] private SegmentFacade segmentfacade;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ListManager>().AsSingle();

            Container.BindInstance(listPanel).AsSingle();

            BindPools();
            BindSignals();
        }

        public void BindPools()
        {
            Container.BindFactory<SegmentFacade, SegmentFacade.Factory>()
           .FromPoolableMemoryPool<SegmentFacade, SegmentFacade.Pool>(poolBinder => poolBinder.WithInitialSize(50)
           .FromSubContainerResolve()
           .ByNewContextPrefab(segmentfacade));

        }

        public void BindSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<OnPressButtonSignal>();

            Container.BindSignal<OnPressButtonSignal>().ToMethod<ListManager>((x, s) => x.RefreshListImages()).FromResolve();
        }
    }
}
