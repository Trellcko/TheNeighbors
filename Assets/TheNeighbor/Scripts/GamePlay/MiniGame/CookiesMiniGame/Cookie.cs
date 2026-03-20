using System;
using UnityEngine;

namespace Trellcko.Gameplay.MiniGame
{
   public class Cookie : MonoBehaviour
   {
      [field: SerializeField] public bool IsGood { get; private set; }
      
      [SerializeField] private float _speed;
      [SerializeField] private Rigidbody _rigidbody;

      private void Start()
      {
         _rigidbody.linearVelocity = new Vector3(0, -_speed, 0);
      }
   }
}