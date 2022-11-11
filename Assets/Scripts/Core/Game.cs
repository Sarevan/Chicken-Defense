using Configs;
using Gameplay;
using Gameplay.Character_hero_;
using Gameplay.Tower;
using UI.Bars;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
    public class Game
    {
        private LevelsConfig levelsConfig;
        private Character character;
        private Tower tower;
        private FireZone fireZone;

        private Level level;

        private int currentIndexWave;
        private float startTime;
        private float totalTime;
        private bool isEndWaves;

        public Tower Tower => tower;

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

        private void SetupLevel(int currentLevel)
        {
            LevelSpawn(currentLevel);
            
            TowerSpawn(currentLevel);

            /*FireZoneSpawn(currentLevel);*/
        }

        private void LevelSpawn(int currentLevel)
        {
            level = Object.Instantiate(GetCurrentLevel(currentLevel));
        }
        
        private void TowerSpawn(int currentLevel)
        {
            tower = Object.Instantiate(GetCurrentTower(currentLevel), level.TowerSpawnPosition,
                Quaternion.identity, level.transform);
            tower.Setup(tower.Position);

            /*tower.TowerDestroy.Destroy += CharacterDrop;*/
        }

        /*private void FireZoneSpawn(int currentLevel)
        {
            fireZone = Object.Instantiate(GetCurrentFireZone(currentLevel), level.FireZoneSpawnPosition,
                Quaternion.identity, level.transform);
            fireZone.Setup(character.SphereCollider);
        }*/

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
        
        private Tower GetCurrentTower(int currentTower)
        {
            var levelsInfoCount = levelsConfig.LevelsInfo.Count;
            var result = levelsConfig.LevelsInfo[currentTower % levelsInfoCount];
            return result.Tower;
        }

        private FireZone GetCurrentFireZone(int currentCollider)
        {
            var levelsInfoCount = levelsConfig.LevelsInfo.Count;
            var result = levelsConfig.LevelsInfo[currentCollider % levelsInfoCount];
            return result.FireZone;
        }

        /*private void CharacterDrop()
        {
            character.Position = Vector3.MoveTowards(character.Position, Tower.TowerDestroy.Ground.position,
                Tower.TowerDestroy.DropSpeed);
            tower.TowerDestroy.Destroy -= CharacterDrop;
        }*/
    }
}