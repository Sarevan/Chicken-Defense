using UnityEngine;
using Zenject;

namespace Gameplay.Character_hero_
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private SphereCollider sphereCollider;
        private Transform character;
        
        public SphereCollider SphereCollider => sphereCollider;
        
    }
}