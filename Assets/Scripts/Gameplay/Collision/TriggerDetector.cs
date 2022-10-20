using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Collision
{
    public class TriggerDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask = -1;

        private List<Collider> colliders = new List<Collider>();

        public List<T> GetComponentsByColliders<T>()
        {
            List<T> temp = new List<T>();
            for (var i = 0; i < colliders.Count; i++)
            {
                if (colliders[i].TryGetComponent<T>(out T coponent))
                {
                    temp.Add(coponent);
                }
            }

            return temp;
        }

        public event Action<Collider> Entered;
        public event Action<Collider> Exit;

        private void OnTriggerEnter(Collider collider)
        {
            //if ((layerMask.value & (1 << collider.gameObject.layer)) > 0)
            {
                colliders.Add(collider);
                Entered?.Invoke(collider);
            }
        }

        private void OnTriggerExit(Collider collider)
        {
           // if ((layerMask.value & (1 << collider.gameObject.layer)) > 0)
            {
                colliders.Remove(collider);
                Exit?.Invoke(collider);
            }
        }
    }
}