using UnityEngine;

namespace Gameplay.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private Transform target;

        public void Setup(Transform target)
        {
            this.target = target;
        }
        
        public void Update()
        {
            EnemyMoveToHero();
        }

        private void EnemyMoveToHero()
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }
    }
}