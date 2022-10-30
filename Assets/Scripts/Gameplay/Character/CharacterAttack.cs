﻿using System.Collections.Generic;
using System.Linq;
using Gameplay.Collision;
using Gameplay.Enemies;
using Gameplay.Shooting.Weapons;
using UnityEngine;

namespace Gameplay.Character
{
    public class CharacterAttack : MonoBehaviour
    {
        [SerializeField] private Transform character;
        [SerializeField] private Weapon weapon;
        
        [SerializeField] private TriggerDetector enemyDetector;
        [SerializeField] private SphereCollider sphereCollider;
        
        [SerializeField] private CharacterAnimator animator;
        
        public Vector3 Position => character.position;
        public SphereCollider SphereCollider => sphereCollider;

        public void Setup(Vector3 position)
        {
            character.position = position;
        }

        private void Update()
        {
            if (DetectedEnemiesInRadiusDamage(out var enemiesInRadiusDamage)) 
                return;
            
            var target = SelectedEnemyToAttack(enemiesInRadiusDamage);

            LookAtEnemy(target.transform);
            
            Attack(target);
            
            GetDistanceFromEnemy(target);
        }

        private void OnEnable()
        {
            enemyDetector.TriggerEnter += EnemyEnterOnFireZone;
        }

        private void OnDisable()
        {
            enemyDetector.TriggerEnter -= EnemyEnterOnFireZone;
        }

        private EnemyMove SelectedEnemyToAttack(List<EnemyMove> detectedEnemiesInRadiusDamage)
        {
            EnemyMove target = detectedEnemiesInRadiusDamage
                .Aggregate((enemy, nextEnemy) => GetDistanceFromEnemy(enemy) < GetDistanceFromEnemy(nextEnemy) ? enemy : nextEnemy);
            return target;
        }

        private bool DetectedEnemiesInRadiusDamage(out List<EnemyMove> detectedEnemiesInRadiusDamage)
        {
            detectedEnemiesInRadiusDamage = enemyDetector.GetComponentsByColliders<EnemyMove>();

            if (detectedEnemiesInRadiusDamage.Count == 0)
            {
                return true;
            }
            return false;
        }

        private float GetDistanceFromEnemy(EnemyMove enemyMove)
        {
            return Vector3.Distance(enemyMove.transform.position, transform.position);
        }

        private void Attack(EnemyMove target)
        {
            if (target != null)
            {
                animator.PlayAttack();
                weapon.Shoot(target.TargetHit);
            }
            animator.StopAttack();
        }

        private void EnemyEnterOnFireZone(Collider enemy)
        {
            //кэшиование переменной
            // todo сделать кэширование
            //enemyDetector.GetComponentsByColliders<Enemy>()
        }

        private void LookAtEnemy(Transform enemyPosition)
        {
            Vector3 relative = character.InverseTransformPoint(enemyPosition.position);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            character.transform.Rotate(0, angle, 0);
        }
    }
}