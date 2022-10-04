using Configs;
using Gameplay;
using Gameplay.Hero;
using UnityEngine;

namespace Core
{
    public class Game
    {
        private LevelsConfig levelsConfig;
        private Character character;

        private Level level;

        public Game(LevelsConfig levelsConfig)
        {
            this.levelsConfig = levelsConfig;
            SetupLevel(levelsConfig.LevelsInfo.Count);
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