using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Enemy;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Gameplay
{
    [Serializable]
    public class Wave
    {
        //level = 30 waves;
        [SerializeField] private float duration; // продолжительность
        [SerializeField] private float timeOneIntervalSpawn; // время одного интервала
        [SerializeField] private int countSpawnEnemiesAtInterval; // число заспавненного противника на интервале
        [SerializeField] private List<Enemy.Enemy> prefabsRandomEnemies; // сами противники в рандомном порядке 

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
        private Transform characterTransform;

        public float Duration => duration;

        public bool IsSetup => isSetup;

        public void Setup(Transform characterTransform)
        {
            this.characterTransform = characterTransform;
            isSetup = true;
            startTime = Time.time;
            ScheduleCreated();
        }

        public void Update()
        {
            if (indexLastItemOfInterval < scheduledSpawnEnemies.Count &&
                scheduledSpawnEnemies[indexLastItemOfInterval] + startTime <= Time.time)
            {
                indexLastItemOfInterval++;

                SpawnRandomEnemy();
            }

            /*foreach (var guaranteedSpawnEnemy in guaranteedSpawnEnemies)
            {
                var count = guaranteedSpawnEnemy.Count;
                var enemyNumbers = Enumerable.Range(1, count).ToList();
                var shedule = enemyNumbers.Select(numberEnemy => numberEnemy * guaranteedSpawnEnemy.Interval).ToList();
            }*/

           //guaranteedSpawnEnemies[0].Interval
           //if (deltaTimeAtEnemy == prefabsRandomEnemies.)
           //{
           //    var guaranteedSpawnRandom = guaranteedSpawnEnemies[Random.Range(0, guaranteedSpawnEnemies.Count)];
           //    Object.Instantiate(guaranteedSpawnRandom.EnemyPrefab, pos, rotation);
           //}
        }

        public void ScheduleCreated()
        {
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
            float deltaTimeAtEnemy = duration / countSpawnRandomEnemies;
            var randomEnemy = prefabsRandomEnemies[Random.Range(0, prefabsRandomEnemies.Count)];
            int countEnemies = countSpawnRandomEnemies + guaranteedSpawnEnemies.Sum(enemiesBox => enemiesBox.Count);
            Vector3 center = spawnPointPosition.position;
            for (int i = 0; i < countSpawnEnemiesAtInterval; i++)
            {
                Vector3 pos = RandomCircle(center, spawnRadius);
                Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, center);
                var enemy = Object.Instantiate(randomEnemy, pos, rotation);
                enemy.Setup(characterTransform);
                
                EnemyLookOnHero(enemy);
            }
        }

        private void EnemyLookOnHero(Enemy.Enemy enemy)
        {
            Vector3 relative = enemy.transform.InverseTransformPoint(characterTransform.position);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            enemy.transform.Rotate(0, angle, 0);
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