using UnityEngine;

namespace Gameplay.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float withinRange;
        [SerializeField] private float speed;
        private Transform target;

        public void Setup(Transform target)
        {
            this.target = target;
        }
        
        public void Update()
        {
            float distance = Vector3.Distance(target.position, transform.position);
            
            if (distance <= withinRange)
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }
    }
}