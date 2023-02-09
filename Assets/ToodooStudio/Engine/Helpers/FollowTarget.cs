// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.Helpers
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float speed;
        
        private void Update()
        {
            var position = target.position;
            transform.position = Vector3.Lerp(transform.position, new Vector3(position.x + offset.x, position.y + offset.y, position.z + offset.z), speed * Time.deltaTime);
        }
    }
}
