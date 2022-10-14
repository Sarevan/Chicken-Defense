﻿using System;
using Gameplay.Collision;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class FireZone : MonoBehaviour
    {
        [SerializeField] private int steps = 1;
        [SerializeField] private float radius = 1;
        [SerializeField] private SphereCollider sphereCenter;
        [SerializeField] private LineRenderer circleRenderer;
        [SerializeField] private TriggerDetector enemyDetector;

        public event Action EnemyOnFireZone;

        public void Start()
        {
            DrawCircle(steps, radius);
            EnemyDetector();
        }

        public void EnemyDetector()
        {
            sphereCenter.radius = radius;
            enemyDetector.Detected += EnemyDetectorOnDetected;
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

                var enemyDetectorCenter = sphereCenter.center;

                Vector3 currentPosition = new Vector3(x, enemyDetectorCenter.y, z);
                circleRenderer.SetPosition(currentStep, currentPosition);

                enemyDetector.Detected -= EnemyDetectorOnDetected;
            }
        }

        private void EnemyDetectorOnDetected(Collider obj)
        {
            EnemyOnFireZone?.Invoke();
        }
    }
}