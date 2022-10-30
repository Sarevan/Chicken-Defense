using System.Collections.Generic;
using UI.ScreensGeneration;
using UnityEngine;

namespace Gameplay
{
    public class Level : SingletonBehaviour<Level>
    {
        //level = 30 waves;
        [SerializeField] private List<Wave> waves;
        [SerializeField] private Transform characterSpawnPosition;
        [SerializeField] private Transform fireZoneSpawnPosition;
        [SerializeField] private Transform towerAttackPosition;

        public Vector3 CharacterSpawnPosition => characterSpawnPosition.position;
        public Vector3 FireZoneSpawnPosition => fireZoneSpawnPosition.position;

        public static Transform Root => Instance.transform;

        public List<Wave> Waves => waves;

        public Transform TowerAttackPosition => towerAttackPosition;
    }
}