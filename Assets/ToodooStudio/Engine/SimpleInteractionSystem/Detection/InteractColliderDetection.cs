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

using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using ToodooStudio.Engine.SimpleInteractionSystem.InteractionInput;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Detection
{
    public enum InteractType
    {
        Single, // Interacts only with the last object in the list.
        Multiple, // Interacts with all objects in the list.
    }
    
    /// <summary>
    /// It is used to detect and interact with an interactive object via a trigger-type collider.
    /// </summary>
    [RequireComponent(typeof(InteractInputReference))]
    public class InteractColliderDetection : MonoBehaviour, IInteractDetection
    {
        [Tooltip("Single: Interacts only with the last object in the list; Multiple: Interacts with all objects in the list.")]
        [SerializeField] private InteractType interactType;
        [Tooltip("If the interactive object is of type hold and fails the interaction, should the class reset the progress? (only works in single mode)")]
        [ShowIf("interactType", InteractType.Single)]
        [SerializeField] private bool resetProgressIfFails = true;
        
        [field:Tooltip("The object responsible for detecting the interaction, useful when you want to access some component in it. If this field is null, will be use this.gameObject.")] [field:SerializeField] public GameObject DetectionObject { get; set; }
        
        /// <summary> List with all detected interactive objects.</summary>
        private readonly List<InteractableBase> _interactableBaseList = new List<InteractableBase>();

        private InputReferenceBase _inputReference;
        /// <summary> The current time the player is holding the button.</summary>
        private float _currentHoldTime;
        
        /// <summary> If the player has already released the button.</summary>
        private bool _releaseHold;
        
        /// <summary> Number of interactive objects that are of type press.</summary>
        private int _pressCount;

        #region UNITY METHODS

        private void Awake()
        {
            _inputReference = GetComponent<InputReferenceBase>();
            
            // Set detection object.
            if (!DetectionObject)
                DetectionObject = gameObject;
        }

        private void Update()
        {
            // Checks if the list is empty.
            if (_interactableBaseList.Count <= 0)
            {
                // Resets the amount of interactables with pressing and time holding the button.
                _currentHoldTime = 0;
                _pressCount = 0;
                return;
            }
            
            // Removes the objects that the script should not interact with.
            for (var i = _interactableBaseList.Count - 1; i >= 0; i--)
            {
                if (_interactableBaseList[i].CanInteract)
                    continue;

                _interactableBaseList.Remove(_interactableBaseList[i]);
            }
            
            // Triggers the action according to the type of input.
            if (_inputReference.KeyboardDownPressed)
            {
                //Only receives interactive objects of type press.
                var pressIEnumerator = _interactableBaseList.Where(item => item.interactionType == InteractionType.Press);
                var pressList = pressIEnumerator.ToList();

                _pressCount = pressList.Count;
                
                if(_pressCount <= 0)
                    return;
                
                switch (interactType)
                {
                    case InteractType.Single:
                        pressList.Last().Interact(this);
                        
                        break;
                    case InteractType.Multiple:
                        foreach (var interactableBase in pressList)
                            interactableBase.Interact(this);

                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            if (_inputReference.KeyboardHoldPressed)
            {
                _releaseHold = false;
                
                //Only receives interactive objects of type hold.
                var holdIEnumerator = _interactableBaseList.Where(item => item.interactionType == InteractionType.Hold);
                var holdList = holdIEnumerator.ToList();

                if (holdList.Count <= 0 && _currentHoldTime > 0)
                {
                    _currentHoldTime = 0f;
                    return;
                }

                _currentHoldTime += Time.deltaTime;
                
                // Triggers the action according to the type of input.
                switch (interactType)
                {
                    case InteractType.Single:

                        if(_pressCount > 0)
                            return;

                        if (holdList.Count <= 0)
                            return;
                        
                        var currentInteractable = holdList.Last();
                        CheckAndUpdateHoldProgress(currentInteractable);

                        break;
                    case InteractType.Multiple:
                        _currentHoldTime += Time.deltaTime;
                        
                        foreach (var interactableBase in holdList)
                            CheckAndUpdateHoldProgress(interactableBase);

                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if(!_releaseHold)
            {
                //Resets the time on interactive objects of type hold.
                var holdIEnumerator = _interactableBaseList.Where(item => item.interactionType == InteractionType.Hold);
                var holdList = holdIEnumerator.ToList();
                
                foreach (var interactableBase in holdList)
                    interactableBase.ResetHoldProgress(this);
                
                _releaseHold = true;
                _currentHoldTime = 0f;
            }
        }

        #endregion

        #region PRIVATE METHODS

        /// <summary>
        /// Updates values and checks whether the action can take place.
        /// </summary>
        /// <param name="interactableBase">Interactive object that will be updated.</param>
        private void CheckAndUpdateHoldProgress(InteractableBase interactableBase)
        {
            interactableBase.UpdateHoldProgress(this, _currentHoldTime / interactableBase.timeToInteract);

            if (_currentHoldTime < interactableBase.timeToInteract)
                return;
            
            var success = interactableBase.Interact(this);

            if (interactType != InteractType.Single || !resetProgressIfFails || success)
                return;
            
            interactableBase.ResetHoldProgress(this);
            _currentHoldTime = 0f;
        }

        #endregion
        
        #region COLLISION DETECTION METHODS

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out InteractableBase detection))
                return;
            
            //Adds the interactable to the list.
            _interactableBaseList.Add(detection);
            
            //Tell the interactive that the detector has added you to the list.
            detection.AddDetection();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out InteractableBase detection))
                return;
            
            //Remove the interactable from the list.
            _interactableBaseList.Remove(detection);
            
            //Tell the interactive that the detector has removed it from the list.
            detection.RemoveDetection();
        }

        #endregion
    }
}