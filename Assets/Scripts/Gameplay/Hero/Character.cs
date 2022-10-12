using System;
using Gameplay.Enemy;
using UnityEngine;

namespace Gameplay.Hero
{
    public class Character : MonoBehaviour
    { 
      [SerializeField]  private Transform transform;


      public Vector3 Position => transform.position;
      /*public Transform Transform => transform;
      */

      public void Setup(Vector3 transform)
      {
          this.transform.position = transform;
      
      }
    }
}