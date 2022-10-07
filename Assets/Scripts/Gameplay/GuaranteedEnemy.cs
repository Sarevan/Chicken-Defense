using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class GuaranteedEnemy
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int count;
        [SerializeField] private float interval;


        public GameObject EnemyPrefab => enemyPrefab;

        public int Count => count;

        public float Interval => interval;
    }
}