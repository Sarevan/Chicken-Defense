using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Collision;
using Gameplay.Enemies;
using Gameplay.Shooting.Weapons;
using UnityEngine;
using Zenject;

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

        private EnemyMove SelectedEnemyToAttack(List<EnemyMove> detectedEnemiesInRadiusDamage)
        {
            EnemyMove target = detectedEnemiesInRadiusDamage
                .Aggregate((enemy, nextEnemy) =>
                    GetDistanceFromEnemy(enemy) < GetDistanceFromEnemy(nextEnemy) ? enemy : nextEnemy);
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

        private void Shoot(EnemyMove target)
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
            //кэшиование переменной
            // todo сделать кэширование
            //enemyDetector.GetComponentsByColliders<Enemy>()
        }
    }
}