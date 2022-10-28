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
                if (colliders[collider] == null)
                {
                    continue;
                }

                if (colliders[collider] != null && colliders[collider].TryGetComponent<T>(out T component))
                {
                    temp.Add(component);
                }
                else
                {
                    break;
                }
            }

            return temp;
        }

        public event Action<Collider> TriggerEnter;
        public event Action<Collider> TriggerExit;

        private void OnTriggerEnter(Collider collider)
        {
            for (var i = colliders.Count - 1; i >= 0; i--)
            {
                if (colliders[i] == null)
                {
                    colliders.RemoveAt(i);
                }
            }

            colliders.Add(collider);
            TriggerEnter?.Invoke(collider);
        }

        private void OnTriggerExit(Collider collider)
        {
            colliders.Remove(collider);
            TriggerExit?.Invoke(collider);
        }
    }
}