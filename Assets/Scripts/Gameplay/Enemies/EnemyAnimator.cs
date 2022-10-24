using System;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int Die = Animator.StringToHash("Die");

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        
        public void PlayMove()
        {
            animator.SetBool(IsMoving,true);
        }
        
        public void PlayAttack()
        {
            animator.SetTrigger(Attack);
        }
        
        public void PlayHit()
        {
            animator.SetTrigger(Hit);
        }

        public void PlayDeath()
        {
            animator.SetTrigger(Die);
        }
    }
}