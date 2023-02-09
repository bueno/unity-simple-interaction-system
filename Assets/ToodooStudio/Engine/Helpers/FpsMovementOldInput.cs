// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

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