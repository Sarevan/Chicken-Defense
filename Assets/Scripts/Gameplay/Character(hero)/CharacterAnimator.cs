using UnityEngine;

namespace Gameplay.Character_hero_
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