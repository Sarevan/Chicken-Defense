using System.Collections.Generic;
using UI.ScreensGeneration;
using UnityEngine;

namespace Gameplay
{
    public class Level : SingletonBehaviour<Level>
    {
        //level = 30 waves;
        [SerializeField] private List<Wave> waves;
        [SerializeField] private Transform towerAttackPosition;
        [SerializeField] private Transform fireZoneSpawnPosition;
        
        public Vector3 FireZoneSpawnPosition => fireZoneSpawnPosition.position;
        
        public List<Wave> Waves => waves;
        public static Transform Root => Instance.transform;
        public Transform TowerAttackPosition => towerAttackPosition;
    }
}