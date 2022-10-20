using Gameplay.Shooting.Bullets;
using UnityEngine;

namespace Gameplay.Shooting.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float fireRate = 1f; // скорострельность 
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform firePoint;

        private float timeToFire; // обратный отсчёт огня
        private bool targetInFireZone;

        private void Awake()
        {
            timeToFire = Time.time + fireRate;
        }

        public void Shoot(Transform target)
        {
            Debug.Log($"Shot {Time.time:f3} ====== {timeToFire:f3}");
            if (Time.time >= timeToFire)
            {
                timeToFire = Time.time + fireRate;
                Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.Setup(target);
            }
        }

        private void BulletLookAtTarget(Transform enemyPosition)
        {
            Vector3 relative = bulletPrefab.transform.InverseTransformPoint(enemyPosition.position);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            bulletPrefab.transform.Rotate(0, angle, 0);
        }
    }
}