using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Gameplay.Character_hero_;
using Gameplay.Enemies;
using Gameplay.Loot;
using Gameplay.Tower_base_;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using Timer = Utils.Timer;

namespace Gameplay
{
    [Serializable]
    public class Wave
    {
        //level = 30 waves;
        [SerializeField] private float duration; // продолжительность
        [SerializeField] private float timeOneIntervalSpawn; // время одного интервала
        [SerializeField] private int countSpawnEnemiesAtInterval; // число заспавненного противника на интервале
        [SerializeField] private List<EnemyMove> prefabsRandomEnemies; // сами противники в рандомном порядке 
        [SerializeField] private int countSpawnRandomEnemies; // противники будут спавниться рандомно с различным интервалом времени

        [SerializeField] private List<GuaranteedSpawnEnemy> guaranteedSpawnEnemies; // противники которые 100% появятся в интервале (Бос)
        
        [SerializeField] private float spawnRadius = 0.5f;
        [SerializeField] private Transform spawnPointPosition;
        [SerializeField] private GameObject portalEnemyFX;
        
        private float startTime;
        private int indexLastItemOfInterval;
        private List<float> scheduledSpawnEnemies;
        private bool isSetup;
        private Tower tower;

        public float Duration => duration;

        public bool IsSetup => isSetup;
        
        [Inject]
        public void Setup(Tower tower)
        {
            this.tower = tower;
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
            EnemyMove randomEnemy = prefabsRandomEnemies[Random.Range(0, prefabsRandomEnemies.Count)];
            int countEnemies = countSpawnRandomEnemies + guaranteedSpawnEnemies.Sum(enemiesBox => enemiesBox.Count);
            Vector3 center = spawnPointPosition.position;
            for (int i = 0; i < countSpawnEnemiesAtInterval; i++)
            {
                Vector3 pos = RandomCircle(center, spawnRadius);
                Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, center);

                Object.Instantiate(portalEnemyFX,pos + Vector3.up,rotation);
                /*diContainer.InstantiatePrefab(randomEnemy, pos, rotation,null);*/
                
                EnemyMove enemy = Object.Instantiate(randomEnemy, pos, rotation);
                
                enemy.Setup(tower.transform);
                
                EnemyLookOnHero(enemy);
            }
        }

        private void EnemyLookOnHero(EnemyMove enemyMove)
        {
            Vector3 relative = enemyMove.transform.InverseTransformPoint(tower.transform.position);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            enemyMove.transform.Rotate(0, angle, 0);
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