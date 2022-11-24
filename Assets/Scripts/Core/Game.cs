using Configs;
using Gameplay;
using Gameplay.Tower_base_;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
    public class Game
    {
        private LevelsConfig levelsConfig;

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
            WavesSpawner();
        }

        private void SetupLevel(int currentLevel)
        {
            LevelSpawn(currentLevel);
        }

        private void LevelSpawn(int currentLevel)
        {
            level = Object.Instantiate(GetCurrentLevel(currentLevel));
        }
        
        private void WavesSpawner()
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
                    currentWave.Setup(level.Tower);
                }

                currentWave.Update();
            }
            else
            {
                isEndWaves = true;
            }
        }

        private Wave GetCurrentLevelWave()
        {
            if (CheckForRangeOutsideWaves()) 
                return null;

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

        private bool CheckForRangeOutsideWaves()
        {
            if (currentIndexWave >= level.Waves.Count)
            {
                return true;
            }

            return false;
        }

        private Level GetCurrentLevel(int currentLevel)
        {
            var levelsInfoCount = levelsConfig.LevelsInfo.Count;
            var result = levelsConfig.LevelsInfo[currentLevel % levelsInfoCount];
            return result.Level;
        }
    }
}