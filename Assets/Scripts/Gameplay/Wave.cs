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
        [SerializeField] private float duration = 60; // продолжительность
        [SerializeField] private float timeOneIntervalSpawn = 10; // время одного интервала
        [SerializeField] private int countSpawnEnemiesAtInterval = 2; // число заспавненного противника на интервале
        [SerializeField] private List<GameObject> prefabsRandomEnemies; // сами противники в рандомном порядке 
        [SerializeField] private int countSpawnRandomEnemies; // противники будут спавниться рандомно с различным интервалом времени
        [SerializeField] private List<GuaranteedSpawnEnemy> guaranteedSpawnEnemies; // противники которые 100% появятся в интервале (Бос)

        [SerializeField] private float spawnRadius = 4f;
        
        
        /*private float startTime;
        private int indexLastItemOfInterval;
        private List<float> scheduledSpawnEnemies;
        
        public void Start()
        {
            startTime = Time.time;
        }

        public void Update()
        {
            if (scheduledSpawnEnemies[indexLastItemOfInterval] + startTime >= Time.time)
            {
                indexLastItemOfInterval++;

               SpawnRandomEnemy();
            }
        }*/
        
        
        public void ScheduleCreated()
        { 
            // временной диапазон рандома противников 
            /*float deltaTimeAtEnemy = duration / countSpawnRandomEnemies; // 6 sec = new enemy (Example: enemy 1 - 3.2s, enemy 2 - 5.4s)*/
            
            // время спавна персонажей 
            var scheduleSpawnEnemies = new List<float>(); 
            
            var countIntervals = (duration / timeOneIntervalSpawn); // 6 sec 

                // interval = 0 , scheduleSpawnEnemies = 9 s;
            for (int interval = 0; interval < countIntervals; interval++)
            {
                float timeStartInterval = (interval * timeOneIntervalSpawn);
                scheduleSpawnEnemies.Add(timeStartInterval + Random.Range(0, timeOneIntervalSpawn));
            }
        }

        public void SpawnRandomEnemy()
        {
            // рандомные + обязательные = общее колличество противников
            int countEnemies = countSpawnRandomEnemies + guaranteedSpawnEnemies.Sum(enemiesBox => enemiesBox.Count);
            while (countEnemies > 0)
            {
                countEnemies--;
                
                var randomEnemy = prefabsRandomEnemies[Random.Range(0,prefabsRandomEnemies.Count - 1)];
                
                Object.Instantiate(randomEnemy,Random.insideUnitSphere * spawnRadius,Quaternion.identity,Level.Root);
            }
        }
    }
}