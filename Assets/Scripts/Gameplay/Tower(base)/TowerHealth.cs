using System;
using Logic;
using UnityEngine;

namespace Gameplay.Tower_base_
{
    public class TowerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float current;
        [SerializeField] private float max;

        [SerializeField] private GameObject dustFX;

        public event Action HealthChanged;
        public event Action MaxHealthBarChanged;
        public event Action CurrentHealthBarChanged;

        public float Current { get => current; set => current = Mathf.Clamp(value,0,max); }
        public float Max {get => max; set => max = value;}

        
        private void Start()
        {
            Current = Max;
            MaxHealthBarChanged?.Invoke();
        }

        public void TakeDamage(float damage)
        {
            if (Current <= 0)
                return;

            Current -= damage;
            CurrentHealthBarChanged?.Invoke();
            SpawnDustFx();

            HealthChanged?.Invoke();
        }
        
        private void SpawnDustFx()
        {
            Instantiate(dustFX, transform.position, Quaternion.identity);
        }
    }
}