using System;
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
        public float Damage => damage;

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

        public void Attack()
        {
            enemyOnAttackPosition = true;
            animator.PlayAttack();
        }
    }
}