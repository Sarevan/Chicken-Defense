using System;
using Gameplay.Tower;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float damage;

        [SerializeField] private EnemyAnimator animator;
        [SerializeField] private EnemyMove enemyMove;

        private EnemyHealth enemyHealth;
        private bool enemyOnAttackPosition;
        
        private void Update()
        {
            if (!enemyOnAttackPosition)
            {
                enemyMove.EnemyMoveToHero();
            }
            else
            {
                Attack();
            }
        }

        private void OnEnable()
        {
            enemyMove.EnemyInHeroAttackZone += Attack;
        }

        private void OnDisable()
        {
            enemyMove.EnemyInHeroAttackZone -= Attack;
        }

        private void OnTriggerEnter(Collider characterCollider)
        {
            if (characterCollider.TryGetComponent(out TowerHealth character))
            {
                character.TakeDamage(damage);
            }
        }

        public void Attack()
        {
            enemyOnAttackPosition = true;
            animator.PlayAttack();
        }
    }
}