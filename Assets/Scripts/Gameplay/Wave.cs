using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Gameplay
{
    [Serializable]
    public class Wave
    {
        //level = 30 waves;
        [SerializeField] private float duration = 10; // продолжительность
        [SerializeField] private float timeOneIntervalSpawn = 5; // время одного интервала
        [SerializeField] private int countSpawnEnemiesAtInterval = 2; // число заспавненного противника на интервале
        [SerializeField] private List<GameObject> prefabsRandomEnemies; // сами противники в рандомном порядке 

        [SerializeField]
        private int countSpawnRandomEnemies; // противники будут спавниться рандомно с различным интервалом времени

        [SerializeField]
        private List<GuaranteedSpawnEnemy> guaranteedSpawnEnemies; // противники которые 100% появятся в интервале (Бос)

        [SerializeField] private float spawnRadius = 0.5f;
        [SerializeField] private Transform spawnPointPosition;


        private float startTime;
        private int indexLastItemOfInterval;
        private List<float> scheduledSpawnEnemies;
        private bool isSetup;

        public float Duration => duration;

        public bool IsSetup => isSetup;

        public void Setup()
        {
            isSetup = true;
            startTime = Time.time;
            ScheduleCreated();
        }

        public void Update()
        {
            if (indexLastItemOfInterval < scheduledSpawnEnemies.Count && scheduledSpawnEnemies[indexLastItemOfInterval] + startTime <= Time.time  )
            {
                indexLastItemOfInterval++;

                SpawnRandomEnemy();
            }
        }

        public void ScheduleCreated()
        {
            /*float deltaTimeAtEnemy = duration / countSpawnRandomEnemies;*/

            scheduledSpawnEnemies = new List<float>();

            var countIntervals = (Duration / timeOneIntervalSpawn);

            for (int interval = 0; interval < countIntervals; interval++)
            {
                float timeStartInterval = (interval * timeOneIntervalSpawn);
                scheduledSpawnEnemies.Add(timeStartInterval + Random.Range(0, timeOneIntervalSpawn));
            }
        }

        private void SpawnRandomEnemy()
        {
            var randomEnemy = prefabsRandomEnemies[Random.Range(0, prefabsRandomEnemies.Count)];
            int countEnemies = countSpawnRandomEnemies + guaranteedSpawnEnemies.Sum(enemiesBox => enemiesBox.Count);
            Vector3 center = spawnPointPosition.position;
            for (int enemy = 0; enemy < countEnemies; enemy++)
            {
                Vector3 pos = RandomCircle(center, spawnRadius);
                Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, center);
                Object.Instantiate(randomEnemy, pos, rotation);
            }
        }

        private Vector3 RandomCircle(Vector3 center, float radius)
        {
            float angle = Random.value * 360;
            Vector3 position;
            position.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            position.y = center.y;
            position.z = center.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            ;
            return position;
        }
    }
}