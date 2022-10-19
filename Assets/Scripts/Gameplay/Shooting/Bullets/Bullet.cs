using UnityEngine;

namespace Gameplay.Shooting.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        
        private Transform firePoint;
        public Transform FirePoint
        {
            get => firePoint;
            set => firePoint = value;
        }

        public void Shoot()
        {
            Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        }
    }
}