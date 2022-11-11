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
        [SerializeField] private Tower tower;
        [SerializeField] private FireZone fireZone;
        
        public Level Level => level;
        public Tower Tower => tower;
        public FireZone FireZone => fireZone;
    }
}