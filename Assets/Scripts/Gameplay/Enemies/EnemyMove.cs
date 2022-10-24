using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private EnemyAnimator animator;

        private Transform target;
        public Transform TargetHit => transform;
        private bool isEnemyHere;

            public void Setup(Transform target)
        {
            this.target = target;
        }

        public void Update()
        {
            EnemyMoveToHero();
        }

        // transfer this method in EnemyAttack class some later 
        public void EnemyAttack()
        {
            isEnemyHere = true;
            animator.PlayAttack(); 
        }

        private void EnemyMoveToHero()
        {
            if (!isEnemyHere)
            {
                animator.PlayMove();
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed); 
            }
            else
            {
                EnemyAttack();
            }
        }
    }
}