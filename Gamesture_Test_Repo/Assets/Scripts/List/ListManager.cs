using Assets.Scripts.Segment;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.List
{
    public class ListManager : IInitializable
    {
        private const string FolderName = "png";
        private const int HighSegment = 200;

        public List<Sprite> ListImages => listImages;

        private List<Sprite> listImages = new List<Sprite>();
        private List<SegmentFacade> segmentFacades = new List<SegmentFacade>();

        private SegmentFacade.Factory segmentFactory;
        private RectTransform listPanel;

        public ListManager(SegmentFacade.Factory segmentFactory, RectTransform listPanel)
        {
            this.segmentFactory = segmentFactory;
            this.listPanel = listPanel;
        }

        public void Initialize()
        {
            RefreshListImages();
        }

        public void RefreshListImages()
        {
            listImages.Clear();
            CreateSpirte();
            RemoveExistSegments();
            SegmentsFactory();
        }

        private void CreateSpirte()
        {
            foreach (Texture2D item in Resources.LoadAll<Texture2D>(FolderName))
            {
                Rect rect = new Rect(0, 0, item.width, item.height);
                Vector2 pivot = new Vector2(0.5f, 0.5f);
                Sprite sprite = Sprite.Create(item, rect, pivot, 100);
                sprite.name = item.name;
                listImages.Add(sprite);
            }
        }

        private void RemoveExistSegments()
        {
            foreach (var item in segmentFacades)
            {
                item.Despawn();
            }
            segmentFacades.Clear();
        }

        private void SegmentsFactory()
        {
            for (int i = 0; i < listImages.Count; i++)
            {
                var segment = segmentFactory.Create();
                segment.transform.position = new Vector3(listPanel.transform.position.x, listPanel.transform.position.y - (segment.GetsPoolNumber - 1) * HighSegment, 
                    listPanel.transform.position.y);
                segmentFacades.Add(segment);
                
            }
        }
    }
}
