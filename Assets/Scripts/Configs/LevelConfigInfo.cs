using System;
using Gameplay;
using Gameplay.Hero;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class LevelConfigInfo
    {
        [SerializeField] private Level level;
        [SerializeField] private CharacterEnemyDetector characterEnemyDetector;
        [SerializeField] private FireZone fireZone;



        public Level Level => level;

        public CharacterEnemyDetector CharacterEnemyDetector => characterEnemyDetector;

        public FireZone FireZone => fireZone;
    }
}