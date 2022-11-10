using System;
using System.Collections;
using Gameplay.Loot;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth health;
        [SerializeField] private EnemyAnimator animator;

        [SerializeField] private GameObject deathFx;
        [SerializeField] private LootElements loot;

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

            loot.Coin.SetActive(true);
            loot.DropCoin();

            StartCoroutine(DestroyTimer());
            SpawnDeathFx();
        }

        private void SpawnDeathFx()
        {
            Instantiate(deathFx, transform.position, Quaternion.identity);
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(1);

            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}