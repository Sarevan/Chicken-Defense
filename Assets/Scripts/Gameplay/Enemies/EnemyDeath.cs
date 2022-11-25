using System.Collections;
using Gameplay.Character_hero_;
using Gameplay.Loot;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth health;
        [SerializeField] private EnemyAnimator animator;

        [SerializeField] private GameObject deathFx;
        
        private Character target;
        private LootFollow coin;

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