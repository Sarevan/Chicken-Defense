using System;
using Gameplay.Collision;
using UnityEngine;

namespace Gameplay.Hero
{
    public class Character : MonoBehaviour
    {
        [Header("Unity Setup Fields")]
        [SerializeField] private Transform character;
        [SerializeField] private TriggerDetector enemyDetector;
        
        
        [Header("Attributes")]
        [SerializeField] private float fireRate = 0.1f; // скорострельность 
        [SerializeField] private float fireCountdown = 0.1f; // обратный отсчёт огня

        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePoint;
        
        private bool enemyInFireZone;


        public Vector3 Position => character.position;

        public void Setup(Vector3 transform)
        {
            character.position = transform;
          
        }

        private void OnEnable()
        {
            enemyDetector.Detected += AttentionOnEnemy;
        }

        private void OnDisable()
        {
            enemyDetector.Detected -= AttentionOnEnemy;
        }

        private void Update()
        {
            EnemyAttack();
        }

        private void AttentionOnEnemy(Collider enemy)
        {
            CheckForEnterEnemy();
            
            EnemyPosition(enemy);
            var firePointPosition = EnemyPosition(enemy);
            firePoint = firePointPosition;
            
            
            LookAtEnemy(EnemyPosition(enemy));
        }

        private void EnemyAttack()
        {
            if (fireCountdown <= 0f && enemyInFireZone)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

        private void Shoot()
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

        private static Transform EnemyPosition(Collider enemy)
        {
            Transform enemyPosition = enemy.transform;
            return enemyPosition;
        }

        private void CheckForEnterEnemy()
        {
            enemyInFireZone = true;
        }

        private void LookAtEnemy(Transform enemyPosition)
        {
            Vector3 relative = character.InverseTransformPoint(enemyPosition.position);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            character.transform.Rotate(0, angle, 0);
        }
    }
}