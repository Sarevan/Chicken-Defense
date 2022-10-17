using UI.ScreensGeneration;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Shooting.Bullets
{
    public class BulletsManager : Utils.Singleton<BulletsManager>
    {
        [SerializeField] private Transform bulletsRoot;

        public Transform ParticleRoot => bulletsRoot;
    }
}