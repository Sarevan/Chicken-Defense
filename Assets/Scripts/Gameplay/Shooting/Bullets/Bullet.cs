using Gameplay.Collision;
using UnityEngine;

namespace Gameplay.Shooting.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private TriggerDetector enemyDetector;

        [SerializeField] private float fireRate = 0.1f; // скорострельность 
        [SerializeField] private float fireCountdown = 0.1f; // обратный отсчёт огня

        private Transform firePoint;
        private bool enemyInFireZone;
        
        private void Update()
        {
            BulletAttack();
        }
        
        private void OnEnable()
        {
            enemyDetector.Detected += BulletAttack;
        }

        private void OnDisable()
        {
            enemyDetector.Detected -= BulletAttack;
        }

        private void BulletAttack(Collider enemy)
        {
            CheckForEnterEnemy();
            
            
            var firePointPosition = EnemyPosition(enemy);
            firePoint = firePointPosition;
        }

        private void BulletAttack()
        {
            if (fireCountdown <= 0f && enemyInFireZone)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
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
        
        private void Shoot()
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}