using Configs;
using Gameplay;
using Gameplay.Tower_base_;
using UI.ScreensGeneration;
using UI.ScreensGeneration.Screens;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private LevelsConfig levelsConfig;
        
        [Inject] private Tower tower;
        private Level level;

        private int currentIndexWave;
        private float startTime;
        private float totalTime;
        private bool isEndWaves;
        
        //transfer this setup in different place some later 

        [Inject]
        public Main(LevelsConfig levelsConfig)
        {
            this.levelsConfig = levelsConfig;
        }
        
        private void Start()
        {
            currentIndexWave = 0;
            startTime = Time.time;
            totalTime = 0f;

            SetupLevel(levelsConfig.LevelsInfo.Count);
            
            GoToMenu();
        }

        private void Update()
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

        private void GoToMenu()
        {
           GameScreen(); 
        }
        
        private void SetupLevel(int currentLevel)
        {
            LevelSpawn(currentLevel);
        }

        private void LevelSpawn(int currentLevel)
        {
            level = Instantiate(GetCurrentLevel(currentLevel));
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
        
        private void GameScreen()
        {
            GameScreen gameMenu = ScreenManager.Instance.ShowScreen<GameScreen>();
            gameMenu.Setup(tower.TowerHealth);
            gameMenu.UpdatedHealthValue();
        }
    }
}