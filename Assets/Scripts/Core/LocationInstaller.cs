using Gameplay;
using Gameplay.Character_hero_;
using Gameplay.Tower;
using UnityEngine;
using Zenject;

namespace Core
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
            BindTower();
            BindCharacter();
            BindFireZone();
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