using Assets.Scripts.Segment;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Zenject
{
    public class SegmentInstaller : MonoInstaller
    {
        [SerializeField] private Image image;
        [SerializeField] private Text nameImage;
        [SerializeField] private Text timeTobuildImage;
        [SerializeField] private RectTransform rectTransform;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SegmentFacade>().FromComponentOnRoot().AsSingle();

            Container.BindInterfacesAndSelfTo<SegmentManager>().AsSingle();

            Container.BindInstance(image).AsSingle();
            Container.BindInstance(rectTransform).AsSingle();
            Container.Bind<Text>().WithId(SegmentInstallerIDs.NameImageID).FromInstance(nameImage).AsCached();
            Container.Bind<Text>().WithId(SegmentInstallerIDs.TimeTobuildImageID).FromInstance(timeTobuildImage).AsCached();

            BindSignals();
        }

        public void BindSignals()
        {
            Container.BindSignal<OnPressButtonSignal>().ToMethod<SegmentManager>((x, s) => x.Refresh()).FromResolve();
        }
    }

    public static class SegmentInstallerIDs
    {
        public const string NameImageID = "NameImage";
        public const string TimeTobuildImageID = "TimeTobuildImage";
    }
}
