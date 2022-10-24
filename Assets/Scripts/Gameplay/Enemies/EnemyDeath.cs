using System;
using System.Collections;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth health;
        [SerializeField] private EnemyAnimator animator;

        [SerializeField] private GameObject deathFx;

        public event Action Happened;

        private void Start()
        {
            health.HealthChanged += HealthChanged;
        }

        private void HealthChanged()
        {
            if (health.Current <= 0)
                Die();
        }

        private void Die()
        {
            health.HealthChanged -= HealthChanged;
            
            animator.PlayDeath();
            
            SpawnDeathFx();
            StartCoroutine(DestroyTimer());
        }

        private void SpawnDeathFx()
        {
            Instantiate(deathFx, transform.position, Quaternion.identity);
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}