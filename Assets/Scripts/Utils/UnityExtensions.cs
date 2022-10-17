using UnityEngine;

namespace Utils
{
    public static class UnityExtensions
    {
        public static void PlayAndDestroy(this ParticleSystem particles)
        {
            ParticleSystem.MainModule particlesMain = particles.main;
            particlesMain.stopAction = ParticleSystemStopAction.Destroy;
            particles.Play();
        }
    }
}