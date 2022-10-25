using System;
using Gameplay.Collision;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class FireZone : MonoBehaviour
    {
        [SerializeField] private int steps = 1;
        [SerializeField] private float radius = 1;
        [SerializeField] private SphereCollider sphereCollider;
        [SerializeField] private LineRenderer circleRenderer;

        public SphereCollider SphereCollider => sphereCollider;

        public void Start()
        {
            DrawCircle(steps, radius);
            EnemyDetector();
        }

        public void EnemyDetector()
        {
            SphereCollider.radius = radius;
        }

        public void DrawCircle(int steps, float radius)
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

                var enemyDetectorCenter = SphereCollider.center;

                Vector3 currentPosition = new Vector3(x, enemyDetectorCenter.y, z);
                circleRenderer.SetPosition(currentStep, currentPosition);
            }
        }
    }
}