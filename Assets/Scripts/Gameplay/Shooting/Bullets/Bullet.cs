using UnityEngine;

namespace Gameplay.Shooting.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletFlySpeed;
        /*[SerializeField] private float damage;*/
        [SerializeField] private float bulletLiveTime = 3;

        private Vector3 direction;

        private void Awake()
        {
            Destroy(gameObject, bulletLiveTime);
        }

        public void Setup(Vector3 direction)
        {
            this.direction = direction;
        }

        private void FixedUpdate()
        {
            transform.position += direction * (Time.deltaTime * bulletFlySpeed);
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