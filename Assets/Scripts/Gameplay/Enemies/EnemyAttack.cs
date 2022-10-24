using System;
using Logic;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator animator;
        [SerializeField] private float damage;

        private EnemyHealth enemyHealth;

        private bool isAttacking;

        public float Damage => damage;

      

        private void Update()
        {
            isAttacking = true;
        }

     
        
        private void OnTriggerEnter(Collider heroCollider)
        {
            if (heroCollider.TryGetComponent(out EnemyMove enemy))
            {
               enemy.EnemyAttack();
            }
        }
    }
}