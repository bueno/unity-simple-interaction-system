// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using ToodooStudio.Engine.SimpleInteractionSystem.InteractionInput;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Detection
{
    /// <summary>
    /// It is used to detect and interact with an interactive object via a raycast.
    /// </summary>
    [RequireComponent(typeof(InteractInputReference))]
    public class InteractRaycastDetection : MonoBehaviour, IInteractDetection
    {
        #region SERIALIZED FIELDS
        
        [Tooltip("Origin of the raycast, If null, it will get the main camera.")]
        [SerializeField] private Transform raycastOrigin;
        [Tooltip("Interactable layer.")]
        [SerializeField] private LayerMask layerMask;
        [Tooltip("Max ray distance.")]
        [Min(0)]
        [SerializeField] private float distance = 0.8f;
        [field:Tooltip("The object responsible for detecting the interaction, useful when you want to access some component in it. If this field is null, will be use this.gameObject.")]
        [field:SerializeField] public GameObject DetectionObject { get; set; }
        [Tooltip("If the interactive object is of type hold and fails the interaction, should the class reset the progress?")]
        [SerializeField] private bool resetProgressIfFails = true;

        #endregion

        /// <summary> Current active interactable.</summary>
        private InteractableBase _currentInteractable;

        private InputReferenceBase _inputReference;
        private float _currentHoldTime;

        #region UNITY METHODS

        private void Awake()
        {
            _inputReference = GetComponent<InputReferenceBase>();
            
            // Set detection object.
            if(!DetectionObject)
                DetectionObject = gameObject;
        }

        private void Start()
        {
            // Set raycast origin object.
            if (!raycastOrigin && Camera.main != null)
                raycastOrigin = Camera.main.transform;
        }

        private void Update()
        {
            //Reset hold time
            if (!_currentInteractable)
            {
                _currentHoldTime = 0;
                return;
            }
            
            if (_inputReference.KeyboardDownPressed && _currentInteractable.interactionType == InteractionType.Press)
            {
                _currentInteractable.Interact(this);
            }

            if (_inputReference.KeyboardHoldPressed && _currentInteractable.interactionType == InteractionType.Hold)
            {
                _currentHoldTime += Time.deltaTime;

                var percent = _currentHoldTime / _currentInteractable.timeToInteract;
                _currentInteractable.UpdateHoldProgress(this, percent);

                if (percent >= 1)
                {
                    var success = _currentInteractable.Interact(this);
                    
                    if(resetProgressIfFails && !success)
                       _currentInteractable.ResetHoldProgress(this);
                }
            }
            else if(_currentInteractable.interactionType == InteractionType.Hold)
            {
                _currentInteractable.ResetHoldProgress(this);
                _currentHoldTime = 0;
            }
        }

        private void FixedUpdate()
        {
            var ray = new Ray(raycastOrigin.position, raycastOrigin.forward);
            
            // Tries to get an interactive object, if the current object is not the same as the detected object.
            if (Physics.Raycast(ray, out var hit, distance , layerMask))
            {
                if(_currentInteractable && (hit.collider.gameObject == _currentInteractable.gameObject))
                    return;
                
                RemoveInteractable();
                
                // Set new current interactable.
                _currentInteractable = hit.collider.GetComponent<InteractableBase>();
                
                if(!_currentInteractable)
                    return;
                
                // Tell the interactive that the detector has added you to the list.
                _currentInteractable.AddDetection();
                return;
            }
            
            RemoveInteractable();
        }

        #endregion

        #region PRIVATE METHODS

        /// <summary>
        /// Clear old interactable
        /// </summary>
        private void RemoveInteractable()
        {
            if (_currentInteractable)
                _currentInteractable.RemoveDetection();

            _currentInteractable = null;
        }

        #endregion
    }
}
