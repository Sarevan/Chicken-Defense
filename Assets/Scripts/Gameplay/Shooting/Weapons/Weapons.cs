using System;
using Gameplay.Collision;
using Gameplay.Shooting.Bullets;
using UnityEngine;

namespace Gameplay.Shooting.Weapons
{
    public class Weapons : MonoBehaviour
    {
        [SerializeField] private float fireRate = 0.1f; // скорострельность 
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private TriggerDetector target;


        private float fireCountdown; // обратный отсчёт огня
        private bool targetInFireZone;

        private void Awake()
        {
            fireCountdown = Time.time + fireRate;
        }

        private void Update()
        {
            Attack(GetComponentInChildren<Collider>());
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
            targetInFireZone = true;
            Attack(enemy);
        }

        private void Attack(Collider enemy)
        {
            if (Time.time >= fireCountdown && targetInFireZone)
            {
                Shoot(enemy);
                fireCountdown = Time.time + fireRate;
            }
        }

        public void Shoot(Collider enemy)
        {
            Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Transform target = EnemyPosition(enemy);
            Vector3 direction = target.position - transform.position;

            bullet.Setup(direction);
        }

        private static Transform EnemyPosition(Collider enemy)
        {
            Transform enemyPosition = enemy.transform;
            return enemyPosition;
        }
    }
}