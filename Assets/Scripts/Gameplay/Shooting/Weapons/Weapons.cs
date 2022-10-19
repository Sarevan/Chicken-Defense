using Gameplay.Collision;
using Gameplay.Shooting.Bullets;
using UnityEngine;

namespace Gameplay.Shooting.Weapons
{
    public class Weapons : MonoBehaviour
    {
        [SerializeField] private float fireRate = 0.1f; // скорострельность 
        [SerializeField] private float fireCountdown = 0.1f; // обратный отсчёт огня
        [SerializeField] private Bullet bullet;
        [SerializeField] private TriggerDetector target;
        
        
        private bool targetInFireZone;
        
        private void Update()
        {
            Attack();
        }
        
        private void OnEnable()
        {
            target.Detected += WeaponsFire;
        }

        private void OnDisable()
        {
            target.Detected -= WeaponsFire;
        }

        private void WeaponsFire(Collider enemy)
        {
            CheckForEnterEnemy();
            
            AimingBulletAtTarget(enemy);
            
            Attack();
        }

        private void CheckForEnterEnemy()
        {
            targetInFireZone = true;
        }

        private void AimingBulletAtTarget(Collider enemy)
        {
            var firePointPosition = EnemyPosition(enemy);
            bullet.FirePoint = firePointPosition;
        }

        private void Attack()
        {
            if (fireCountdown <= 0f && targetInFireZone)
            {
                bullet.Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

        private static Transform EnemyPosition(Collider enemy)
        {
            Transform enemyPosition = enemy.transform;
            return enemyPosition;
        }
    }
}