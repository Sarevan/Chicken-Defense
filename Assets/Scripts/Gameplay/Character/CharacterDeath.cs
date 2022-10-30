using System;
using UnityEngine;

namespace Gameplay.Character
{
    public class CharacterDeath : MonoBehaviour
    {
        [SerializeField] private CharacterHealth health;
        
        [SerializeField] private GameObject tower;
        [SerializeField] private GameObject towerExplosion;
        
        /*[SerializeField] private Transform ground;
        [SerializeField] private Transform defender;
        [SerializeField] private float dropSpeed;*/

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
            /*DefenderDrop();*/
        }

        /*private void DefenderDrop()
        {
            defender.position = Vector3.MoveTowards(defender.position, ground.position, dropSpeed);
        }*/
    }
}