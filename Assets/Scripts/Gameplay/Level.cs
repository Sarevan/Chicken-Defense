using System.Collections.Generic;
using Gameplay.Tower_base_;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private List<Wave> waves;

        private Tower tower;
        
        public List<Wave> Waves => waves;
        public Tower Tower => tower;

        [Inject]
        private void Setup(Tower tower)
        {
            this.tower = tower;
        }
    }
}