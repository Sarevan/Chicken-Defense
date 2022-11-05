using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float seconds = 1f;
        
        private IEnumerator WaitingTime()
        {
            yield return new WaitForSeconds(seconds);
        }
    }
}