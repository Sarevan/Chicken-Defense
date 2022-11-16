using Configs;
using Gameplay.Character_hero_;
using Gameplay.Tower_base_;
using UI.ScreensGeneration;
using UI.ScreensGeneration.Screens;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private AllConfigs allConfigs;

        private Game game;
        private Tower tower;

        //transfer this setup in different place some later 
        [Inject]
        public void Setup( Tower tower)
        {
            this.tower = tower;
        }
        private void Start()
        {
            game = new Game(allConfigs.LevelsConfig);
            GoToMenu();
        }

        private void Update()
        {
            game.Update();
        }

        private void GoToMenu()
        {
           GameScreen(); 
        }

        private void GameScreen()
        {
            GameScreen gameMenu = ScreenManager.Instance.ShowScreen<GameScreen>();
            gameMenu.Setup(tower.TowerHealth);
            gameMenu.UpdatedHealthValue();
        }
    }
}