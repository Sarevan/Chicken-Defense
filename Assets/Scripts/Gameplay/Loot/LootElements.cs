using UnityEngine;
using DG.Tweening;

namespace Gameplay.Loot
{
    public class LootElements : MonoBehaviour
    {
        [SerializeField] private GameObject coinObject;
        
        [SerializeField] private Vector3 endPosition;
        [SerializeField] private float jumpPower;
        [SerializeField] private int jumpCount;
        [SerializeField] private float duration;

        //To get dependency from Wave and take then enemy position 
        public void DropCoin(Vector3 position)
        {
            var coin  = Instantiate(coinObject, position, Quaternion.identity); // add enemy spawn position
            coin.transform.DOJump(endPosition,jumpPower,jumpCount,duration);
        }
    }
}