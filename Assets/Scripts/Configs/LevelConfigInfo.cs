using System;
using Gameplay;
using Gameplay.Character;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class LevelConfigInfo
    {
        [SerializeField] private Level level;
        [SerializeField] private Character character;
        [SerializeField] private FireZone fireZone;



        public Level Level => level;

        public Character Character => character;

        public FireZone FireZone => fireZone;
    }
}