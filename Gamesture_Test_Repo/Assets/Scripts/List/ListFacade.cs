using Assets.Scripts.Zenject;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.List
{
    public class ListFacade : MonoBehaviour
    {
        private SignalBus signalBus;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public void Button()
        {
            signalBus.Fire<OnPressButtonSignal>();
        }
    }
}
