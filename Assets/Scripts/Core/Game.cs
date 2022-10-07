using System.Collections.Generic;
using Configs;
using Gameplay;
using Gameplay.Hero;
using Unity.VisualScripting;
using UnityEngine;

namespace Core
{
    public class Game
    {
        private LevelsConfig levelsConfig;
        private Character character;

        private Level level;
        private Wave wave;

        public Game(LevelsConfig levelsConfig)
        {
            
            this.levelsConfig = levelsConfig;

            SetupLevel(levelsConfig.LevelsInfo.Count);

            wave = LevelWaves();
        }

        private Wave LevelWaves()
        {
            for (int wave = 0; wave < level.Waves.Count; wave++)
            {
                if (level.Waves.Count == 0)
                {
                    return null;
                }

                var levelWave = level.Waves[wave];
                return levelWave;
            }

            return null;
        }


        public void Update()
        {
            wave.ScheduleCreated();
            wave.SpawnRandomEnemy();
        }


        public void SetupLevel(int currentLevel)
        {
            level = Object.Instantiate(GetCurrentLevel(currentLevel));
            character = Object.Instantiate(GetCurrentCharacter(currentLevel), level.CharacterSpawnPosition,
                Quaternion.identity, level.transform);
        }

        private Character GetCurrentCharacter(int currentCharacter)
        {
            var levelsInfoCount = levelsConfig.LevelsInfo.Count;
            var result = levelsConfig.LevelsInfo[currentCharacter % levelsInfoCount];
            return result.Character;
        }

        private Level GetCurrentLevel(int currentLevel)
        {
            var levelsInfoCount = levelsConfig.LevelsInfo.Count;
            var result = levelsConfig.LevelsInfo[currentLevel % levelsInfoCount];
            return result.Level;
        }
    }
}