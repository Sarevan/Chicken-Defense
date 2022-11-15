using Gameplay;
using Gameplay.Character_hero_;
using Gameplay.Tower_base_;
using UnityEngine;
using Zenject;

namespace Core.Zenject.SceneContext
{
    public class LocationInstaller : MonoInstaller
    {
        [Header("Prefabs objects")]
        [SerializeField] private GameObject character;
        [SerializeField] private GameObject fireZone;
        [SerializeField] private GameObject tower;

        [Header("Spawn positions")]
        [SerializeField] private Transform characterSpawnPosition;
        [SerializeField] private Transform fireZoneSpawnPosition;
        [SerializeField] private Transform towerSpawnPosition;
        
        public override void InstallBindings()
        {
            BindCharacter();
            BindTower();
            BindFireZone();
        }

        private void BindCharacter()
        {
            Character characterPrefab = Container
                .InstantiatePrefabForComponent<Character>(character, characterSpawnPosition.position,
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
                .InstantiatePrefabForComponent<Tower>(tower, towerSpawnPosition.position, Quaternion.identity,
                    null);

            Container
                .Bind<Tower>()
                .FromInstance(towerPrefab)
                .AsSingle();
        }

        private void BindFireZone()
        {
            FireZone fireZonePrefab = Container
                .InstantiatePrefabForComponent<FireZone>(fireZone, fireZoneSpawnPosition.position,
                    Quaternion.identity,
                    null);

            Container
                .Bind<FireZone>()
                .FromInstance(fireZonePrefab)
                .AsSingle();
        }
    }
}