using Assets.Scripts.List;
using Assets.Scripts.Zenject;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Segment
{
    public class SegmentManager : IInitializable
    {
        private readonly ListManager listManager;
        private readonly SegmentFacade segmentFacade;

        private readonly Text nameImage;
        private readonly Text timeToBuildImage;
        private readonly Image image;

        public SegmentManager(ListManager listManager, Image image, SegmentFacade segmentFacade,
           [Inject(Id = SegmentInstallerIDs.NameImageID)] Text nameImage,
           [Inject(Id = SegmentInstallerIDs.TimeTobuildImageID)] Text timeToBuildImage)
        {
            this.listManager = listManager;
            this.image = image;
            this.nameImage = nameImage;
            this.timeToBuildImage = timeToBuildImage;
            this.segmentFacade = segmentFacade;
        }

        public void Initialize()
        {
            image.sprite = listManager.ListImages[segmentFacade.transform.GetSiblingIndex()];
        }
    }
}
