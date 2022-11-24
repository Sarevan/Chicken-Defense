using Gameplay;
using Gameplay.Character_hero_;
using Gameplay.Loot;
using Gameplay.Tower_base_;
using UnityEngine;
using Zenject;

namespace Core.Zenject.SceneContext
{
    public class LocationInstaller : MonoInstaller
    {
        [Header("Scene objects")]
        [SerializeField] private GameObject character;
        [SerializeField] private GameObject fireZone;
        [SerializeField] private GameObject tower;

        [Header("Spawn positions")]
        [SerializeField] private Transform characterSpawn;
        [SerializeField] private Transform fireZoneSpawn;
        [SerializeField] private Transform towerSpawn;
        
        /*[Header("Spawn loots")]
        [SerializeField] private GameObject coin;*/
        
        public override void InstallBindings()
        {
            BindCharacter();
            BindTower();
            BindFireZone();
            /*BindCoins();*/
        }

        /*private void BindCoins()
        {
            LootFollow coinPrefab = Container
                .InstantiatePrefabForComponent<LootFollow>(coin, transform.position,
                    Quaternion.identity,
                    null);
            
            Container
                .Bind<LootFollow>()
                .FromInstance(coinPrefab)
                .AsSingle();
        }*/

        private void BindCharacter()
        {
            Character characterPrefab = Container
                .InstantiatePrefabForComponent<Character>(character, characterSpawn.position,
                    Quaternion.identity,
                    null);

            Container
                .Bind<Character>()
                .FromInstance(characterPrefab)
                .AsSingle();
        }
        
        private void BindTower()
        {
            Tower towerPrefab = Container
                .InstantiatePrefabForComponent<Tower>(tower, towerSpawn.position, Quaternion.identity,
                    null);

            Container
                .Bind<Tower>()
                .FromInstance(towerPrefab)
                .AsSingle();
        }

        private void BindFireZone()
        {
            FireZone fireZonePrefab = Container
                .InstantiatePrefabForComponent<FireZone>(fireZone, fireZoneSpawn.position,
                    Quaternion.identity,
                    null);

            Container
                .Bind<FireZone>()
                .FromInstance(fireZonePrefab)
                .AsSingle();
        }
    }
}