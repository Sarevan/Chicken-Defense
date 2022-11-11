using Gameplay.Character_hero_;
using UnityEngine;
using Zenject;

namespace Core
{
    public class LocationInstaller : MonoInstaller
    {
       [SerializeField] private Transform characterSpawnPosition;
       [SerializeField] private GameObject character;
        public override void InstallBindings()
        {
            BindCharacter();
        }
        
        private void BindCharacter()
        {
            Character characterPrefab = Container
                .InstantiatePrefabForComponent<Character>(character, characterSpawnPosition.position, Quaternion.identity,
                    null);

            Container
                .Bind<Character>()
                .FromInstance(characterPrefab)
                .AsSingle();
        }
    }
}