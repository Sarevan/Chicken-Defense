using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Collision
{
    public class TriggerDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask = -1;

        private List<Collider> colliders = new();

        public List<T> GetComponentsByColliders<T>()
        {
            List<T> temp = new List<T>();
            for (var collider = 0; collider < colliders.Count; collider++)
            {
                if (colliders[collider].TryGetComponent<T>(out T component))
                {
                    temp.Add(component);
                }
            }

            return temp;
        }

        public event Action<Collider> Entered;
        public event Action<Collider> Exit;

        private void OnTriggerEnter(Collider collider)
        {
            {
                colliders.Add(collider);
                Entered?.Invoke(collider);
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            {
                colliders.Remove(collider);
                Exit?.Invoke(collider);
            }
        }
    }
}