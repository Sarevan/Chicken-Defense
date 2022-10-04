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
        [SerializeField] private Character character;

        public Level Level => level;

        public Character Character => character;
    }
}