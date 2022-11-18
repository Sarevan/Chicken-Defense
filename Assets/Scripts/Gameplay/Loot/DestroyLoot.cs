using Gameplay.Collision;
using UnityEngine;

namespace Gameplay.Loot
{
    public class DestroyLoot : MonoBehaviour
    {
        [SerializeField] private EasyTriggerDetector detectorAttack;
        [SerializeField] private GameObject destroyObject;
        
        private void OnEnable()
        {
            detectorAttack.Detected += Destroy;
        }

        private void OnDisable()
        {
            detectorAttack.Detected -= Destroy;
        }
        
        private void Destroy(Collider chicken)
        {
            Destroy(destroyObject);
        }
    }
}