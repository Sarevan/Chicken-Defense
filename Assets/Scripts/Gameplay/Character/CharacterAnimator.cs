using UnityEngine;

namespace Gameplay.Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private static readonly int Attack = Animator.StringToHash("Attack");
        
        public void PlayAttack()
        {
            animator.SetTrigger(Attack);
        }
    }
}