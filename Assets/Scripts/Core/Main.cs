using System;
using Configs;
using Gameplay.Enemies;
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
        }

        private void Update()
        {
         game.Update();
        }
    }
}