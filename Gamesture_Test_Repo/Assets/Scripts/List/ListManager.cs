using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.List
{
    public class ListManager : IInitializable
    {
        private readonly List<Sprite> listImages = new List<Sprite>();

        public List<Sprite> ListImages => listImages;

        public void Initialize()
        {
            RefreshListImages();
        }

        public void RefreshListImages()
        {
            listImages.Clear();
            foreach (Texture2D item in Resources.LoadAll<Texture2D>("png"))
            {
                Rect rect = new Rect(0, 0, item.width, item.height);
                Vector2 pivot = new Vector2(0.5f, 0.5f);
                Sprite sprite = Sprite.Create(item, rect, pivot);
                listImages.Add(sprite);
            }
        }
    }
}
