using System;
using UnityEngine;
using Utils;

namespace Gameplay.Shooting.Bullets
{
    public class BulletViewComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem trailBulletParticle;
        [SerializeField] private ParticleSystem hitEnemyParticle;

        private void OnEnable()
        {
            if (trailBulletParticle != null && trailBulletParticle.gameObject != null)
            {
                foreach (TrailRenderer trailRenderer in trailBulletParticle.GetComponentsInChildren<TrailRenderer>())
                {
                    trailRenderer.autodestruct = false;
                }
                trailBulletParticle.Play();
            }
        }

        public void DisableTrail()
        {
            if (trailBulletParticle != null && trailBulletParticle.gameObject != null)
            {
                foreach (TrailRenderer trailRenderer in trailBulletParticle.GetComponentsInChildren<TrailRenderer>())
                {
                    trailRenderer.Clear();
                }
                
                trailBulletParticle.Stop();
            }
        }

        public void PlayHit()
        {
            if (hitEnemyParticle == null)
            {
                return;
            }

            ParticleSystem hitParticleInstance = Instantiate(
                hitEnemyParticle,
                hitEnemyParticle.transform.position,
                hitEnemyParticle.transform.rotation,
                BulletsManager.Instance.ParticleRoot);

            hitParticleInstance.PlayAndDestroy();
        }

        public void PlayHit(Vector3 position)
        {
            if (hitEnemyParticle == null)
            {
                return;
            }

            ParticleSystem hitParticleInstance = Instantiate(
                hitEnemyParticle,
                position,
                hitEnemyParticle.transform.rotation,
                BulletsManager.Instance.ParticleRoot);
            
            hitParticleInstance.PlayAndDestroy();
        }
    }
}