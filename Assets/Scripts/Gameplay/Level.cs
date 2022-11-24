using System.Collections.Generic;
using Gameplay.Tower_base_;
using UI.ScreensGeneration;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Level : MonoBehaviour
    {
        //level = 30 waves;
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