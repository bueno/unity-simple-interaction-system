// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.Helpers
{
   public class MovementOldInput : MonoBehaviour
   {
      private Rigidbody _rigidbody;
      [SerializeField] private float speed;

      private void Awake()
      {
         _rigidbody = GetComponent<Rigidbody>();
      }

      private void Update()
      {
         var input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
         _rigidbody.velocity = input * speed;
      }
   }
}
