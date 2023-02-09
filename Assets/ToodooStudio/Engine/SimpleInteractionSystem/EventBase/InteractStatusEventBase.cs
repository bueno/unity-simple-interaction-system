// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.EventBase
{
    /// <summary>
    /// Inherit from it to implement commands when the state of the interactable changes, when the interactable is activated or deactivated.
    /// </summary>
    public abstract class InteractStatusEventBase : MonoBehaviour
    {
        /// <summary> The interactable. </summary>
        protected InteractableBase InteractableBase;

        protected virtual  void Awake() => InteractableBase = GetComponent<InteractableBase>();
        
        // Registers the abstract methods in events.
        protected virtual  void OnEnable() => InteractableBase.OnInteractStatusChange += OnInteractionStatusUpdate;
        // Unsubscribes the abstract methods from events.
        protected virtual  void OnDisable() => InteractableBase.OnInteractStatusChange -= OnInteractionStatusUpdate;

        /// <summary>
        /// Triggered when the state of the interactable changes, when the interaction is activated or deactivated.
        /// </summary>
        /// <param name="newValue">New interactable state value.</param>
        protected abstract void OnInteractionStatusUpdate(bool newValue);
    }
}