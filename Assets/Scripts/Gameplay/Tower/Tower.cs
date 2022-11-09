using UnityEngine;

namespace Gameplay.Tower
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private Transform tower;
        [SerializeField] private TowerDestroy towerDestroy;
        [SerializeField] private TowerHealth towerHealth;

        public Vector3 Position => tower.position;
        public TowerDestroy TowerDestroy => towerDestroy;
        public TowerHealth TowerHealth => towerHealth;

        public void Setup(Vector3 towerPosition)
        {
            tower.position = towerPosition;
        }
    }
}