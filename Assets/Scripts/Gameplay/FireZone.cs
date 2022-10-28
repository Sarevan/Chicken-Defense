using Gameplay.Hero;
using UnityEngine;

namespace Gameplay
{
    public class FireZone : MonoBehaviour
    {
        [SerializeField] private int steps = 1;
        [SerializeField] private float radius = 1;
        [SerializeField] private LineRenderer circleRenderer;

        private SphereCollider sphereCollider;
        
        public void Start()
        {
            DrawCircle(steps, radius);
            RadiusDetector();
        }

        public void Setup(SphereCollider sphereCollider)
        {
            this.sphereCollider = sphereCollider;
        }
        
        private void RadiusDetector()
        {
           radius =  sphereCollider.radius;
        }

        private void DrawCircle(int steps, float radius)
        {
            circleRenderer.positionCount = steps;
            for (int currentStep = 0; currentStep < steps; currentStep++)
            {
                float circumferenceProgress = (float) currentStep / steps;

                float currentRadian = circumferenceProgress * 2 * Mathf.PI;
                float xScaled = Mathf.Cos(currentRadian);
                float zScaled = Mathf.Sin(currentRadian);

                float x = xScaled * radius;
                float z = zScaled * radius;

                var enemyDetectorCenter =   sphereCollider.center;

                Vector3 currentPosition = new Vector3(x, enemyDetectorCenter.y, z);
                circleRenderer.SetPosition(currentStep, currentPosition);
            }
        }
    }
}