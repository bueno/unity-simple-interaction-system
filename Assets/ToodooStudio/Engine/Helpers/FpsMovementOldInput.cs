/*
 MIT License

 Copyright (c) 2023+ TOODOO STUDIO LLC.

 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 SOFTWARE.
*/

using UnityEngine;

namespace ToodooStudio.Engine.Helpers
{
    public class FpsMovementOldInput : MonoBehaviour
    {
        [Header("Movement")]
        public float moveSpeed;
        
        [Header("Camera Orientation")]
        [SerializeField] private Transform orientation;
        [SerializeField] private float sensibility = 400;
        [SerializeField] private float minAngle = -70f;
        [SerializeField] private float maxAngle = 70f;

        private float _yRotation;
        private float _xRotation;

        private float _horizontalInput;
        private float _verticalInput;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.freezeRotation = true;
        }

        private void Update()
        {
            PlayerMovement();
            CameraMovement();
        }

        private void PlayerMovement()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            _verticalInput = Input.GetAxisRaw("Vertical");

            var move = (orientation.forward * _verticalInput + orientation.right * _horizontalInput) * moveSpeed;
            move.y = 0f;
            
            _rigidbody.velocity = move;
        }
        
        private void CameraMovement()
        {
            var mouseX = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * sensibility * Time.deltaTime;

            _yRotation += mouseX;
            _xRotation -= mouseY;

            _xRotation = Mathf.Clamp(_xRotation, minAngle, maxAngle);

            orientation.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
        }
    }
}