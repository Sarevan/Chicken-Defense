using UnityEngine;

namespace Gameplay.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Transform target;
        public Transform TargetHit => transform;

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

        public void TakeDamage(float damage)
        {
            throw new System.NotImplementedException();
        }
    }
}