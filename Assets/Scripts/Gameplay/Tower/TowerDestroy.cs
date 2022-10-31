using UnityEngine;

namespace Gameplay.Tower
{
    public class TowerDestroy : MonoBehaviour
    {
        [SerializeField] private TowerHealth health;
        
        [SerializeField] private GameObject tower;
        [SerializeField] private GameObject towerExplosion;
        
        [SerializeField] private GameObject explosionFx;
        
        private void Start()
        {
            health.HealthChanged += HealthChanged;
        }

        private void HealthChanged()
        {
            if (health.Current <= 0)
                DestroyTower();
        }

        private void DestroyTower()
        {
            health.HealthChanged -= HealthChanged;

            SpawnDeathFx();

            Explosion();
        }

        private void SpawnDeathFx()
        {
            Instantiate(explosionFx, transform.position, Quaternion.identity);
        }

        private void Explosion()
        {
            tower.SetActive(false);
            towerExplosion.SetActive(true);
        }
    }
}