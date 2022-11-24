using System;
using UnityEngine;
using DG.Tweening;
using Gameplay.Character_hero_;
using Gameplay.Collision;
using Gameplay.Enemies;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Loot
{
    public class LootFollow : MonoBehaviour
    {
        [SerializeField] private float minModifier = 7;
        [SerializeField] private float maxModifier = 11;
        
        private Character target;

        Vector3 velocity = Vector3.zero;
        private bool isFollowing = false;

        [Inject]
        private void Setup(Character target)
        {
            this.target = target;
        }
        private void Update()
        {
            Setup(target);
            if(isFollowing)
            {
                transform.position = Vector3.SmoothDamp(transform.position, target.transform.position,ref velocity,
                    Time.deltaTime * Random.Range(minModifier,maxModifier));
            }
        }
        
        public void StartFollowing()
        {
            isFollowing = true;
        }

        
    }
}