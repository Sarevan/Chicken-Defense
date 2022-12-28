using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Collision;
using Gameplay.Enemies;
using Gameplay.Shooting.Weapons;
using UnityEngine;

namespace Gameplay.Character_hero_
{
    public class CharacterAttack : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private Weapon weapon;
        [SerializeField] private TriggerDetector enemyDetector;
        [SerializeField] private CharacterAnimator animator;

        [SerializeField] private float timeAttack = 0.1f;
        private bool isAttack;
        
        private void Update()
        {
            if (DetectedEnemiesInRadiusDamage(out var enemiesInRadiusDamage))
                return;

            var target = SelectedEnemyToAttack(enemiesInRadiusDamage);

            LookAtEnemy(target.transform);

            if (isAttack)
                return;

            Shoot(target);
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

        private Enemy SelectedEnemyToAttack(List<Enemy> detectedEnemiesInRadiusDamage)
        {
            Enemy target = detectedEnemiesInRadiusDamage
                .Aggregate((enemy, nextEnemy) =>
                    GetDistanceFromEnemy(enemy) < GetDistanceFromEnemy(nextEnemy) ? enemy : nextEnemy);
            return target;
        }

        private bool DetectedEnemiesInRadiusDamage(out List<Enemy> detectedEnemiesInRadiusDamage)
        {
            detectedEnemiesInRadiusDamage = enemyDetector.GetComponentsByColliders<Enemy>();

            if (detectedEnemiesInRadiusDamage.Count == 0)
            {
                return true;
            }

            return false;
        }

        private float GetDistanceFromEnemy(Enemy enemy)
        {
            return Vector3.Distance(enemy.transform.position, transform.position);
        }

        private void Shoot(Enemy target)
        {
            if (target != null && !isAttack)
            {
                weapon.Shoot(target.TargetHit);
                StartCoroutine(Attack());
            }
        }

        IEnumerator Attack()
        {
            isAttack = true;
            animator.PlayAttack();
            yield return new WaitForSeconds(timeAttack);
            animator.StopAttack();
            isAttack = false;
        }

        private void LookAtEnemy(Transform enemyPosition)
        {
            Vector3 relative = character.transform.InverseTransformPoint(enemyPosition.position);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            character.transform.Rotate(0, angle, 0);
        }

        private void EnemyEnterOnFireZone(Collider enemy)
        {
        }
    }
}