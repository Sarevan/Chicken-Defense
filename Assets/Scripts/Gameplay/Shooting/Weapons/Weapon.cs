using Gameplay.Shooting.Bullets;
using UnityEngine;

namespace Gameplay.Shooting.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float fireRate = 1f;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform firePoint;
        
        private float timeToFire;
        private bool targetInFireZone;
        
        private void Awake()
        {
            timeToFire = Time.time + fireRate;
        }
        
        public void Shoot(Transform target)
        {
            if (Time.time >= timeToFire)
            {
                timeToFire = Time.time + fireRate;
                Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.Setup(target);
            }
        }
    }
}