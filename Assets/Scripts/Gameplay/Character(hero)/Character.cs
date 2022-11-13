using UnityEngine;

namespace Gameplay.Character_hero_
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private SphereCollider sphereCollider;
        
        [SerializeField] private Transform characterOnGround;
        [SerializeField] private float dropSpeed;
        
        public SphereCollider SphereCollider => sphereCollider;

        public void CharacterDrop()
        {
            transform.position = Vector3.MoveTowards(transform.position, characterOnGround.position, dropSpeed);
        }
    }
}