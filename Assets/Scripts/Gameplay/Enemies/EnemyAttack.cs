using Gameplay.Tower_base_;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float damage;

        [SerializeField] private EnemyAnimator animator;
        [SerializeField] private Enemy enemy;

        private EnemyHealth enemyHealth;
        private bool enemyOnAttackPosition;
        
        private void Update()
        {
            if (!enemyOnAttackPosition)
            {
                enemy.EnemyMoveToHero();
            }
            else
            {
                Attack();
            }
        }

        private void OnEnable()
        {
            enemy.EnemyInHeroAttackZone += Attack;
        }

        private void OnDisable()
        {
            enemy.EnemyInHeroAttackZone -= Attack;
        }

        private void OnTriggerEnter(Collider characterCollider)
        {
            if (characterCollider.TryGetComponent(out TowerHealth character))
            {
                character.TakeDamage(damage);
            }
        }

        private void Attack()
        {
            enemyOnAttackPosition = true;
            animator.PlayAttack();
        }
    }
}