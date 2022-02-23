using Assets.Scripts.List;
using Assets.Scripts.Zenject;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Segment
{
    public class SegmentManager : IInitializable
    {
        private const string TimeToBuildMessage = "Czas do stworzenia pliku: ";

        private ListManager listManager;
        private SegmentFacade segmentFacade;

        private Text nameImage;
        private Text timeToBuildImage;
        private Image image;

        private int myNumber;

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
            Refresh();
        }

        public void Refresh()
        {
            if (segmentFacade.isActiveAndEnabled)
            {
                SetImage();
                UpdateTexts();
            }
        }

        private void UpdateTexts()
        {
            nameImage.text = listManager.ListImages[myNumber].name;

            timeToBuildImage.text = (TimeToBuildMessage + Time.time);
        }

        private void SetImage()
        {
            myNumber = segmentFacade.GetsPoolNumber - 1;
            image.sprite = listManager.ListImages[myNumber];
        }
    }
}
