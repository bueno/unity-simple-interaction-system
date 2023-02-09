// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.Helpers
{
    public class Billboard : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, _camera.transform.eulerAngles.y, 0f);
        }
    }
}
