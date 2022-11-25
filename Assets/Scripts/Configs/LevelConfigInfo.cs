using System;
using Gameplay;
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