using UnityEngine;

namespace Gameplay.Tower
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private Transform tower;
        [SerializeField] private TowerDestroy towerDestroy;
        public Vector3 Position => tower.position;

        public TowerDestroy TowerDestroy => towerDestroy;

        public void Setup(Vector3 towerPosition)
        {
            tower.position = towerPosition;
       
        }
    }
}