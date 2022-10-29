using System;
using Core;
using Logic;
using UnityEngine;

namespace Gameplay.Character
{
    public class CharacterHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float current;
        [SerializeField] private float max;

        [SerializeField] private GameObject dustFX;
        
        public event Action HealthChanged;
        
        public float Current { get => current; set => current = value; }
        public float Max {get => max; set => max = value;}
        
        public void TakeDamage(float damage)
        {
            if (Current <= 0)
                return;

            Current -= damage;
            SpawnDustFx();

            HealthChanged?.Invoke();
        }
        
        private void SpawnDustFx()
        {
            Instantiate(dustFX, transform.position, Quaternion.identity);
        }
    }
}