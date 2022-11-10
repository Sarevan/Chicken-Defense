using UnityEngine;
using DG.Tweening;

namespace Gameplay.Loot
{
    public class LootElements : MonoBehaviour
    {
        [SerializeField] private GameObject coin;

        public GameObject Coin => coin;

        public void DropCoin()
        {
             Instantiate(coin, transform.position, Quaternion.identity);
        }
        
        
    }
}