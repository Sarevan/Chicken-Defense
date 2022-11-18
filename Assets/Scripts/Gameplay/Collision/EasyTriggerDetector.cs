using System;
using UnityEngine;

namespace Gameplay.Collision
{
    public class EasyTriggerDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask = -1;
        
        public event Action<Collider> Detected;
        
        private void OnTriggerEnter(Collider collider)
        {
            if ((layerMask.value & (1 << collider.transform.gameObject.layer)) > 0)
            {
                Detected?.Invoke(collider);
            }
        }
    }
}