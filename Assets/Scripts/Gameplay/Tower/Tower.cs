using UnityEngine;
using Zenject;

namespace Gameplay.Tower
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