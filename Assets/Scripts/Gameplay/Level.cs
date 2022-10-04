using UnityEngine;

namespace Gameplay
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform characterSpawnPosition;

        public Vector3 CharacterSpawnPosition => characterSpawnPosition.position;
    }
}