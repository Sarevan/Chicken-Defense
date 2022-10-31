using UnityEngine;

namespace Gameplay.Tower
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private Transform tower;
      
        public Vector3 Position => tower.position;
        
        public void Setup(Vector3 position)
        {
            tower.position = position;
        }
    }
}