using UnityEngine;

namespace Gameplay.Tower_base_
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TowerDestroy towerDestroy;
        [SerializeField] private TowerHealth towerHealth;

        private Transform tower;
        
        public TowerDestroy TowerDestroy => towerDestroy;
        public TowerHealth TowerHealth => towerHealth;
    }
}