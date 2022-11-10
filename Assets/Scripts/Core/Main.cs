using Configs;
using UI.ScreensGeneration;
using UI.ScreensGeneration.Screens;
using UnityEngine;

namespace Core
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private AllConfigs allConfigs;

        private Game game;

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
            gameMenu.Setup(game.Tower.TowerHealth);
            gameMenu.UpdatedHealthValue();
        }
    }
}