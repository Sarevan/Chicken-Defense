using UnityEngine;

namespace Gameplay.Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private static readonly int IsAttack = Animator.StringToHash("Attack");
        
        public void PlayAttack()
        {
            animator.SetBool(IsAttack,true);
        }
        public void StopAttack()
        {
            animator.SetBool(IsAttack,false);
        }
    }
}