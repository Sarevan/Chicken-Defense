using System;
using Gameplay.Collision;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private EnemyAnimator animator;
        [SerializeField] private EasyTriggerDetector detectorAttack;

        private Transform target;

        public Transform TargetHit => transform;
        
        public event Action EnemyInHeroAttackZone;

        public void Setup(Transform target)
        {
            this.target = target;
        }
        
        private void OnEnable()
        {
            detectorAttack.Detected += AttackZoneDetectorOnDetected;
        }

        private void OnDisable()
        {
            detectorAttack.Detected -= AttackZoneDetectorOnDetected;
        }

        public void EnemyMoveToHero()
        {
            animator.PlayMove();
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }

        private void AttackZoneDetectorOnDetected(Collider obj)
        {
            EnemyInHeroAttackZone?.Invoke();
        }
    }
}