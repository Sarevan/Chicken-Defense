using UnityEngine;

public class BulletViewComponent : MonoBehaviour
{
    [SerializeField] private ParticleSystem trailParticle;
    [SerializeField] private ParticleSystem hitParticle;

    private void OnEnable()
    {
        if (trailParticle != null && trailParticle.gameObject != null)
        {
            foreach (TrailRenderer trailRenderer in trailParticle.GetComponentsInChildren<TrailRenderer>())
            {
                trailRenderer.autodestruct = false;
            }

            trailParticle.Play();
        }
    }

    public void DisableTrail()
    {
        if (trailParticle != null && trailParticle.gameObject != null)
        {
            foreach (TrailRenderer trailRenderer in trailParticle.GetComponentsInChildren<TrailRenderer>())
            {
                trailRenderer.Clear();
            }

            trailParticle.Stop();
        }
    }

    /*public void PlayHit()
    {
        if (hitParticle == null)
        {
            return;
        }

        ParticleSystem hitParticleInstance = Instantiate(
            hitParticle,
            hitParticle.transform.position,
            hitParticle.transform.rotation,
            BulletsManager.Instance.ParticleRoot);

        hitParticleInstance.PlayAndDestroy();
    }

    public void PlayHit(Vector3 position)
    {
        if (hitParticle == null)
        {
            return;
        }
        ParticleSystem hitParticleInstance = Instantiate(
            hitParticle,
            position,
            hitParticle.transform.rotation,
            BulletsManager.Instance.ParticleRoot);

        hitParticleInstance.PlayAndDestroy();
    }*/
}
