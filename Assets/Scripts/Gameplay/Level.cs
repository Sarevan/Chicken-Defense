using System.Collections.Generic;
using Gameplay.Collision;
using UI;
using UI.ScreensGeneration;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class Level : SingletonBehaviour<Level>
    {
        //level = 30 waves;
        [SerializeField] private List<Wave> waves;
        [SerializeField] private Transform characterSpawnPosition;
        [SerializeField] private Transform towerAttackPosition;

        public Vector3 CharacterSpawnPosition => characterSpawnPosition.position;

        public static Transform Root => Instance.transform;

        public List<Wave> Waves => waves;

        public Transform TowerAttackPosition => towerAttackPosition;
        
    }
}