using Assets.Scripts.Segment;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Zenject
{
    public class SegmentInstaller : MonoInstaller
    {
        [SerializeField] private readonly Image image;
        [SerializeField] private readonly Text nameImage;
        [SerializeField] private readonly Text timeTobuildImage;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SegmentFacade>().FromComponentOnRoot().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SegmentManager>().AsSingle();
            Container.BindInstance(image).AsSingle();

            Container.Bind<Text>().WithId(SegmentInstallerIDs.NameImageID).
                FromInstance(nameImage).AsCached();

            Container.Bind<Text>().WithId(SegmentInstallerIDs.TimeTobuildImageID).
                FromInstance(timeTobuildImage).AsCached();
        }
    }

    public static class SegmentInstallerIDs
    {
        public const string NameImageID = "NameImage";
        public const string TimeTobuildImageID = "TimeTobuildImage";
    }
}
