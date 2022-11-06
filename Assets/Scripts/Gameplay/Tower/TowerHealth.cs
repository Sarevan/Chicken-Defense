using System;
using Logic;
using UI.Bars;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Tower
{
    public class TowerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private HealthBar healthBar; // will add in through Screen Manager
        [SerializeField] private float current;
        [SerializeField] private float max;

        [SerializeField] private GameObject dustFX;
        
        public event Action HealthChanged;
        
        public float Current { get => current; set => current = value; }
        public float Max {get => max; set => max = value;}

        private void Start()
        {
            Current = Max;
            healthBar.SetMaxHealth(Max);
        }

        public void TakeDamage(float damage)
        {
            if (Current <= 0)
                return;

            Current -= damage;
            healthBar.SetHealth(Current);
            SpawnDustFx();

            HealthChanged?.Invoke();
        }
        
        private void SpawnDustFx()
        {
            Instantiate(dustFX, transform.position, Quaternion.identity);
        }
    }
}