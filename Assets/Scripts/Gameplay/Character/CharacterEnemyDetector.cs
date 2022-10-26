using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Collision;
using Gameplay.Enemies;
using Gameplay.Shooting.Bullets;
using Gameplay.Shooting.Weapons;
using UnityEngine;

namespace Gameplay.Hero
{
    public class CharacterEnemyDetector : MonoBehaviour
    {
        [SerializeField] private Transform character;
        [SerializeField] private TriggerDetector enemyDetector;
        [SerializeField] private Weapon weapon;
        [SerializeField] private SphereCollider sphereCollider;
        
        public Vector3 Position => character.position;

        public SphereCollider SphereCollider
        {
            get => sphereCollider;
            set => sphereCollider = value;
        }

        public void Setup(Vector3 position)
        {
            character.position = position;
        }

        private void Update()
        {
            if (DetectedEnemiesInRadiusDamage(out var enemiesInRadiusDamage)) 
                return;
            
            var target = SelectedEnemyToAttack(enemiesInRadiusDamage);

            LookAtEnemy(target.transform);
            
            weapon.Shoot(target.TargetHit);
           

            GetDistanceFromEnemy(target);
        }

        private EnemyMove SelectedEnemyToAttack(List<EnemyMove> detectedEnemiesInRadiusDamage)
        {
            EnemyMove target = detectedEnemiesInRadiusDamage
                .Aggregate((enemy, nextEnemy) => GetDistanceFromEnemy(enemy) < GetDistanceFromEnemy(nextEnemy) ? enemy : nextEnemy);
            return target;
        }

        private bool DetectedEnemiesInRadiusDamage(out List<EnemyMove> detectedEnemiesInRadiusDamage)
        {
            detectedEnemiesInRadiusDamage = enemyDetector.GetComponentsByColliders<EnemyMove>();

            if (detectedEnemiesInRadiusDamage.Count == 0)
            {
                return true;
            }

            return false;
        }

        private void OnEnable()
        {
            enemyDetector.TriggerEnter += EnemyEnterOnFireZone;
        }

        private void OnDisable()
        {
            enemyDetector.TriggerEnter -= EnemyEnterOnFireZone;
        }

        private float GetDistanceFromEnemy(EnemyMove enemyMove)
        {
            return Vector3.Distance(enemyMove.transform.position, transform.position);
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