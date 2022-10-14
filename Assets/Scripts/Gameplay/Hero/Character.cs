using Gameplay.Collision;
using UnityEngine;

namespace Gameplay.Hero
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Transform character;
        [SerializeField] private TriggerDetector enemyDetector;
        private bool isActive;


        public Vector3 Position => character.position;

        public void Setup(Vector3 transform)
        {
            this.character.position = transform;
          
        }

        private void OnEnable()
        {
            enemyDetector.Detected += CharacterAttack;
        }

        private void OnDisable()
        {
            enemyDetector.Detected -= CharacterAttack;
        }
        
        private void CharacterAttack(Collider enemy)
        {
            isActive = true;
            var enemyPosition = enemy.transform;
            
            Vector3 relative = character.InverseTransformPoint(enemyPosition.position);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            character.transform.Rotate(0,angle,0);
        }
    }
}