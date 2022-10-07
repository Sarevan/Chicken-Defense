using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Gameplay
{
    public class Level : SingletonBehaviour<Level>
    {
        //level = 30 waves;
        [SerializeField] private List<Wave> waves;
        [SerializeField] private Transform characterSpawnPosition;

        public Vector3 CharacterSpawnPosition => characterSpawnPosition.position;

        public static Transform Root => Instance.transform;

        public List<Wave> Waves => waves;
    }
}