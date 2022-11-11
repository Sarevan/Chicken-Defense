using UnityEngine;
using Zenject;

namespace Gameplay.Character_hero_
{
    public class Character : MonoBehaviour
    {
        /*[SerializeField] private SphereCollider sphereCollider;*/
        private Transform character;
        
        /*public SphereCollider SphereCollider => sphereCollider;*/

        
        public void Setup(Character character)
        {
            this.character =  character.transform;
        }
        
        public void LookAtEnemy(Transform enemyPosition)
        {
            Vector3 relative = character.InverseTransformPoint(enemyPosition.position);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            character.transform.Rotate(0, angle, 0);
        }
    }
}