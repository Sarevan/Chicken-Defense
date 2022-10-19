using System;
using Gameplay.Collision;
using UnityEngine;

namespace Gameplay.Hero
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Transform character;
        [SerializeField] private TriggerDetector enemyDetector;
        
        
        public Vector3 Position => character.position;

        public void Setup(Vector3 transform)
        {
            character.position = transform;
        }

        private void OnEnable()
        {
            enemyDetector.Detected += EnemyEnterOnFireZone;
        }

        private void OnDisable()
        {
            enemyDetector.Detected -= EnemyEnterOnFireZone;
        }

      

        private void EnemyEnterOnFireZone(Collider enemy)
        {
            EnemyPosition(enemy);

            LookAtEnemy(EnemyPosition(enemy));
        }
        
        private static Transform EnemyPosition(Collider enemy)
        {
            Transform enemyPosition = enemy.transform;
            return enemyPosition;
        }
        
        private void LookAtEnemy(Transform enemyPosition)
        {
            Vector3 relative = character.InverseTransformPoint(enemyPosition.position);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            character.transform.Rotate(0, angle, 0);
        }
    }
}