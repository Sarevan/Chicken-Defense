using Gameplay.Character_hero_;
using Gameplay.Tower;
using UnityEngine;
using Zenject;

namespace Core
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private GameObject character;
        [SerializeField] private GameObject tower;
        
        [SerializeField] private Transform towerSpawnPosition;
        [SerializeField] private Transform characterSpawnPosition;

        public override void InstallBindings()
        {
            BindTower();
            BindCharacter();
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
    }
}