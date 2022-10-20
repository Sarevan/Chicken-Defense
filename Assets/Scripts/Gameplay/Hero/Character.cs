using System;
using System.Linq;
using Gameplay.Collision;
using Gameplay.Enemies;
using Gameplay.Shooting.Weapons;
using UnityEngine;

namespace Gameplay.Hero
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Transform character;
        [SerializeField] private TriggerDetector enemyDetector;
        [SerializeField] private Weapon weapon;

        public Vector3 Position => character.position;

        public void Setup(Vector3 transform)
        {
            character.position = transform;
        }

        private void Update()
        {
            var detectedEnemiesInRadiusDamage = enemyDetector.GetComponentsByColliders<Enemy>();
            if (detectedEnemiesInRadiusDamage.Count == 0)
            {
                return;
            }

            Enemy target = detectedEnemiesInRadiusDamage
                .Aggregate((enemy, enemy1) => getDistance(enemy) < getDistance(enemy1) ? enemy : enemy1);

            LookAtEnemy(target.transform);
            weapon.Shoot(target.TargetHit);

            float getDistance(Enemy enemy)
            {
                return Vector3.Distance(enemy.transform.position, transform.position);
            }
        }

        private void OnEnable()
        {
            enemyDetector.Entered += EnemyEnterOnFireZone;
        }

        private void OnDisable()
        {
            enemyDetector.Entered -= EnemyEnterOnFireZone;
        }

        private void EnemyEnterOnFireZone(Collider enemy)
        {
            //кэшиование переменной
            // todo сделать кэширование
            //enemyDetector.GetComponentsByColliders<Enemy>()
        }

        private void LookAtEnemy(Transform enemyPosition)
        {
            Vector3 relative = character.InverseTransformPoint(enemyPosition.position);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            character.transform.Rotate(0, angle, 0);
        }
    }
}