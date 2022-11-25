using NaughtyAttributes;
using UnityEngine;

namespace Gameplay.Shooting.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletFlySpeed = 1f;

        [SerializeField] private float damage;
        [SerializeField] private float bulletLiveTime = 2;
        [SerializeField] private GameObject trailBulletEffect;

        [ShowNonSerializedField] private Transform target;
        
        private bool targetInFireZone;

        private void Awake()
        {
            Destroy(gameObject, bulletLiveTime);
        }

        public void Setup(Transform enemyPosition)
        {
            targetInFireZone = true;
            target = enemyPosition;
            Vector3 direction = transform.position - target.position;
            transform.forward = direction.normalized;
        }

        private void Update()
        {
            if (targetInFireZone && target != null)
            {
                Vector3 direction = target.position - transform.position;
                direction.Normalize();
                float bulletSpeed = bulletFlySpeed * Time.deltaTime;

                if (direction.magnitude >= bulletSpeed)
                {
                    HitTarget();
                }
                transform.position += direction * (bulletFlySpeed * Time.deltaTime);
            }
        }

        private void HitTarget()
        {
            Instantiate(trailBulletEffect, transform.position, transform.rotation);
        }
        
        private void OnTriggerEnter(Collider enemyCollider)
        {
            if (enemyCollider.TryGetComponent(out Enemies.EnemyHealth enemy))
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}