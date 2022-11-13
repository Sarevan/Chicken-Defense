using UnityEngine;
using Zenject;

namespace Gameplay.Character_hero_
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private SphereCollider sphereCollider;
        
        public SphereCollider SphereCollider => sphereCollider;
    }
}