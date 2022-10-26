using System;
using Configs;
using Gameplay;
using Gameplay.Hero;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
    public class Game
    {
        private LevelsConfig levelsConfig;
        private CharacterEnemyDetector characterEnemyDetector;
        private FireZone fireZone;



        private Level level;

        private int currentIndexWave;
        private float startTime;
        private float totalTime;
        private bool isEndWaves;

        

        public Game(LevelsConfig levelsConfig)
        {
            this.levelsConfig = levelsConfig;

            currentIndexWave = 0;
            startTime = Time.time;
            totalTime = 0f;

            SetupLevel(levelsConfig.LevelsInfo.Count);
        }


        public void Update()
        {
            if (isEndWaves)
            {
                return;
            }
            
            var currentWave = GetCurrentLevelWave();
            if (currentWave != null)
            {
                if (currentWave.IsSetup != true)
                {
                    currentWave.Setup(level.TowerAttackPosition);
                }
                currentWave.Update();
            }
            else
            {
                isEndWaves = true;
            }
        }


        public void SetupLevel(int currentLevel)
        {
            level = Object.Instantiate(GetCurrentLevel(currentLevel));
            
            characterEnemyDetector = Object.Instantiate(GetCurrentCharacter(currentLevel), level.CharacterSpawnPosition,
                Quaternion.identity, level.transform);
            characterEnemyDetector.Setup(characterEnemyDetector.Position);

            fireZone = Object.Instantiate(GetCurrentFireZone(currentLevel), level.CharacterSpawnPosition,
                Quaternion.identity, level.transform);
            fireZone.Setup(characterEnemyDetector.SphereCollider);
        }
        
        private Wave GetCurrentLevelWave()
        {
            if (currentIndexWave >= level.Waves.Count)
            {
                return null;
            }   
          
            if (totalTime + level.Waves[currentIndexWave].Duration <= Time.time - startTime)
            {
                totalTime += level.Waves[currentIndexWave].Duration;
                currentIndexWave++;
                if (currentIndexWave >= level.Waves.Count)
                {
                    return null;
                }
            }

            return level.Waves[currentIndexWave];
        }

        private Level GetCurrentLevel(int currentLevel)
        {
            var levelsInfoCount = levelsConfig.LevelsInfo.Count;
            var result = levelsConfig.LevelsInfo[currentLevel % levelsInfoCount];
            return result.Level;
        }

        private CharacterEnemyDetector GetCurrentCharacter(int currentCharacter)
        {
            var levelsInfoCount = levelsConfig.LevelsInfo.Count;
            var result = levelsConfig.LevelsInfo[currentCharacter % levelsInfoCount];
            return result.CharacterEnemyDetector;
        }

        private FireZone GetCurrentFireZone(int currentCollider)
        {
            var levelsInfoCount = levelsConfig.LevelsInfo.Count;
            var result = levelsConfig.LevelsInfo[currentCollider % levelsInfoCount];
            return result.FireZone;
        }
    }
}