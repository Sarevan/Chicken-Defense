using System;
using Gameplay;
using Gameplay.Character_hero_;
using Gameplay.Tower;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class LevelConfigInfo
    {
        [SerializeField] private Level level;
        
        public Level Level => level;
       
    }
}