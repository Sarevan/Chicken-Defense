using System;
using UnityEngine;

namespace Gameplay.Hero
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Transform transform;
        [SerializeField] private FireZone fireZone;


        public Vector3 Position => transform.position;

        public void Setup(Vector3 transform)
        {
            this.transform.position = transform;
        }

        private void OnEnable()
        {
            fireZone.EnemyOnFireZone += CharacterAttack;
        }

        private void OnDisable()
        {
            fireZone.EnemyOnFireZone -= CharacterAttack;
        }

        private void CharacterAttack()
      {
          Debug.Log("Enemy detect successfully ");
      }
    }
}