using Assets.Scripts.Zenject;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Segment
{
    public class SegmentFacade : MonoBehaviour
    {
        private Text nameImage;
        private Text timeToBuildImage;
        private Image image;

        [Inject]
        private void Construct(Image image, [Inject(Id = SegmentInstallerIDs.NameImageID)] Text nameImage,
           [Inject(Id = SegmentInstallerIDs.TimeTobuildImageID)] Text timeToBuildImage)
        {
            this.image = image;
            this.nameImage = nameImage;
            this.timeToBuildImage = timeToBuildImage;
        }

    }
}
