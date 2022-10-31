using System;
using Gameplay;
using Gameplay.Character;
using Gameplay.Tower;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class LevelConfigInfo
    {
        [SerializeField] private Level level;
        [SerializeField] private Character character;
        [SerializeField] private Tower tower;
        [SerializeField] private FireZone fireZone;
        
        public Level Level => level;
        public Character Character => character;
        public Tower Tower => tower;
        public FireZone FireZone => fireZone;
    }
}