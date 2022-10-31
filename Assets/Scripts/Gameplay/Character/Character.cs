using UnityEngine;

namespace Gameplay.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Transform character;
        [SerializeField] private SphereCollider sphereCollider;
        public Vector3 Position => character.position;
        public SphereCollider SphereCollider => sphereCollider;
         public void Setup(Vector3 position)
        {
            character.position = position;
        }

         public void LookAtEnemy(Transform enemyPosition)
         {
             Vector3 relative = character.InverseTransformPoint(enemyPosition.position);
             float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
             character.transform.Rotate(0, angle, 0);
         }
    }
}