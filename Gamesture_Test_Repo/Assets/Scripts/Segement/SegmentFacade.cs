using Assets.Scripts.List;
using Assets.Scripts.Zenject;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Segment
{
    public class SegmentFacade : MonoBehaviour, IPoolable<IMemoryPool>
    {
        public int GetsPoolNumber => myNumber;

        private IMemoryPool pool;
        private int myNumber;

        public void Despawn()
        {
            pool.Despawn(this);
        }

        public void OnSpawned(IMemoryPool pool)
        {
            this.pool = pool;
            myNumber = pool.NumActive;
        }

        public void OnDespawned()
        {
        }

        public class Factory : PlaceholderFactory<SegmentFacade>
        {
        } 

        public class Pool : MonoPoolableMemoryPool<IMemoryPool, SegmentFacade>
        {
        }      
    }
}
