using Assets.Scripts.Segment;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.List
{
    public class ListFacade : MonoBehaviour
    {
        [SerializeField] private readonly SegmentFacade myGameObject;
        private ListManager listManager;
        private GameObject listPanel;

        [Inject]
        private void Construct(ListManager listManager, GameObject listPanel)
        {
            this.listManager = listManager;
            this.listPanel = listPanel;
        }

        private void Start()
        {

            for (int i = 0; i < listManager.ListImages.Count; i++)
            {
                // Instantiate(myGameObject, listPanel.transform);
                //newObject.transform.position = listManager.ListImages[i];
            }
        }
    }
}
