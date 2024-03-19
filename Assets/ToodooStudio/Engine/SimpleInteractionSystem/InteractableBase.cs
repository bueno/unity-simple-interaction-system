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
using NaughtyAttributes;
using ToodooStudio.Engine.SimpleInteractionSystem.Detection;
using ToodooStudio.Engine.SimpleInteractionSystem.UI;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem
{
    public enum InteractionType
    {
        Press,
        Hold
    }

    /// <summary>
    /// Base class of the interaction system, inherit from it to create new interactive objects.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public abstract class InteractableBase : MonoBehaviour, IInteractableUI
    {
        #region EVENTS

        /// <summary> Called at the beginning of the interaction, it returns the object of interactivity and whether it was successful.</summary>
        public event Action<InteractableBase, bool> OnInteractStart;
        ///<summary> Called when activating or deactivating the interaction, it returns the new state.</summary>
        public event Action<bool> OnInteractStatusChange;
        /// <summary> Called when the interactive object is added to a detector, it returns the object of the interactivity.</summary>
        public event Action<InteractableBase> OnInteractableAdded;
        /// <summary> Called when the interactive object is removed from a detector, it returns the object of the interactivity.</summary>
        public event Action<InteractableBase> OnInteractableRemoved;

        /// <summary> Called when the holding progress begins, it returns the object of the interactivity. </summary>
        public event Action<InteractableBase> OnHoldUpdateStart;
        /// <summary> Called when the holding progress is updated, it returns the object of the interactivity and current progress in percent. </summary>
        public event Action<InteractableBase, float> OnHoldUpdateProgress;
        /// <summary> Called when the holding progress stops, it returns the object of the interactivity. </summary>
        public event Action<InteractableBase> OnHoldUpdateStop;

        #endregion

        #region PUBLIC FIELDS

        [field:Header("UI Settings")]
        [field:Tooltip("If this field is null, will be use game object transform. It is used as a reference point for the ui.")]
        [field:SerializeField] public Transform InteractableTransform { get; set; }
        
        [field:Tooltip("UI offset on Y axis.")]
        [field:SerializeField] public float OffsetY { get; set; } = 0.65f;
        
        [field:Tooltip("Interaction description.")]
        [field:SerializeField] public string ActionText { get; set; }

        ///<summary> Checks if interactable is active.</summary>
        public bool CanInteract { get; set; } = true;

        [Header("Interaction Settings")]
        public InteractionType interactionType = InteractionType.Press;
        [ShowIf("interactionType", InteractionType.Hold)]
        public float timeToInteract = 2f;

        #endregion

        ///<summary> It is used to disable and enable the interaction collider </summary> 
        private Collider _interactableCollider;
        
        private UIInteractionManagerBase _uiInteractionManagerBase;
        /// <summary> It is Used to identify the beginning of the holding action. </summary>
        private bool _startHold;

        #region UNITY METHODS

        private void Awake()
        {
            _uiInteractionManagerBase = FindObjectOfType<UIInteractionManagerBase>();
            
            // Get collider.
            _interactableCollider = GetComponent<Collider>();

            // Set ui point.
            if (!InteractableTransform)
                InteractableTransform = transform;
        }

        protected virtual void Start()
        {
            if(!_uiInteractionManagerBase)
                Debug.Log("You need the UIInteraction script on scene.");
        }

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Calls the interactive object action.
        /// </summary>
        /// <param name="detectionReceiver">The object that detected the interactable.</param>
        public bool Interact(IInteractDetection detectionReceiver)
        {
            //Assigns the result of the interaction.
            var value = InteractBehavior(detectionReceiver);
            OnInteractStart?.Invoke(this, value);

            return value;
        }
        
        /// <summary>
        /// Tells the user interface about the progress of the hold, please use ResetHoldProgress method to reset the progress.
        /// </summary>
        /// <param name="detectionReceiver">The object that detected the interactable.</param>
        /// <param name="percent">Percent of progress.</param>
        public void UpdateHoldProgress(IInteractDetection detectionReceiver, float percent)
        {
            if (!_startHold)
            {
                _startHold = true;
                OnHoldUpdateStart?.Invoke(this);
            }
            
            OnHoldUpdateProgress?.Invoke(this, percent);
            
            if(_uiInteractionManagerBase)
                _uiInteractionManagerBase.UpdateHoldProgress(this, percent);
        }

        /// <summary>
        /// Reset progress on ui and trigger stop event.
        /// </summary>
        /// <param name="detectionReceiver">The object that detected the interactable.</param>
        public void ResetHoldProgress(IInteractDetection detectionReceiver)
        {
            if(_uiInteractionManagerBase)
                _uiInteractionManagerBase.UpdateHoldProgress(this, 0f);
            
            _startHold = false;
            OnHoldUpdateStop?.Invoke(this);
        }

        /// <summary>
        /// Enable interactable collider and UI.
        /// </summary>
        public virtual void EnableInteract()
        {
            HandleInteractable(true);
        }

        /// <summary>
        /// Disable interactable collider and UI.
        /// </summary>
        public virtual void DisableInteract()
        {
            HandleInteractable(false);
        }

        /// <summary>
        /// Change the description of the action, and tell ui that the text should change.
        /// </summary>
        /// <param name="newText">New description.</param>
        /// <param name="forceUpdateUI">Does the user interface need updating?</param>
        public void UpdateInteractionText(string newText, bool forceUpdateUI = true)
        {
            ActionText = newText;
            
            //if(forceUpdateUI)
                _uiInteractionManagerBase.UpdateText(this);
        }
        
        /// <summary>
        /// Tells you that the interactive object has been added by a detector.
        /// </summary>
        public void AddDetection()
        {
            if(_uiInteractionManagerBase)
                _uiInteractionManagerBase.AddInteractable(this);
            OnInteractableAdded?.Invoke(this);
        }
        
        /// <summary>
        /// Tells the interactive object to be removed by a detector.
        /// </summary>
        public void RemoveDetection()
        {
            if(_uiInteractionManagerBase)
                _uiInteractionManagerBase.RemoveInteractable(this);
            
            OnInteractableRemoved?.Invoke(this);
        }

        #endregion

        #region PRIVATE METHODS

        /// <summary>
        /// It is used to disable and enable the interaction collider and ui.
        /// </summary>
        /// <param name="value">New value</param>
        private void HandleInteractable(bool value)
        {
            if(_interactableCollider)
                _interactableCollider.enabled = value;
            CanInteract = value;
            OnInteractStatusChange?.Invoke(value);
        }

        #endregion
        
        /// <summary>
        /// Calls the interactive object action internally.
        /// </summary>
        /// <param name="detectionReceiver">The object that detected the interactable.</param>
        /// <returns>Success</returns>
        protected abstract bool InteractBehavior(IInteractDetection detectionReceiver);
    }
}