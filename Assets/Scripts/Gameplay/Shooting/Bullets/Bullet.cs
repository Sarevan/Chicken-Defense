using NaughtyAttributes;
using UnityEngine;

namespace Gameplay.Shooting.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletFlySpeed = 0.01f;

        /*[SerializeField] private float damage;*/
        [SerializeField] private float bulletLiveTime = 5;

        [ShowNonSerializedField]
        private Transform target;

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
            if (targetInFireZone)
            {
                Vector3 direction = target.position - transform.position;
                direction.Normalize();
                float bulletSpeed = bulletFlySpeed * Time.deltaTime;

                if (direction.magnitude <= bulletSpeed)
                {
                    HitTarget();
                }

                /*target.Translate(direction.normalized * bulletSpeed,Space.World);*/
                transform.position += direction * (bulletFlySpeed * Time.deltaTime);
            }
        }

        private void HitTarget()
        {
            Debug.Log("We hit in something ");
        }

        /*private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemies.Enemy enemy))
            {
                enemy.TakeDamage(damage);
            }
        }*/
    }
}