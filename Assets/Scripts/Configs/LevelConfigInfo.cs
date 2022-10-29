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
        [SerializeField] private CharacterAttack characterAttack;
        [SerializeField] private FireZone fireZone;



        public Level Level => level;

        public CharacterAttack CharacterAttack => characterAttack;

        public FireZone FireZone => fireZone;
    }
}