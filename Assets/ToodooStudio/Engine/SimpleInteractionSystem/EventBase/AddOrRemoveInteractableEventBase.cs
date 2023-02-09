// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.EventBase
{
    /// <summary>
    /// Inherit from it to implement commands when the interactable is added to or removed from a detector.
    /// </summary>
    public abstract class AddOrRemoveInteractableEventBase : MonoBehaviour
    {
        /// <summary> The interactable. </summary>
        protected InteractableBase InteractableBase;

        protected virtual  void Awake() => InteractableBase = GetComponent<InteractableBase>();
        
        // Registers the abstract methods in events.
        protected virtual  void OnEnable()
        {
            InteractableBase.OnInteractableAdded += OnInteractableAdded;
            InteractableBase.OnInteractableRemoved += OnInteractableRemoved;
        }

        // Unsubscribes the abstract methods from events.
        protected virtual void OnDisable()
        {
            InteractableBase.OnInteractableAdded -= OnInteractableAdded;
            InteractableBase.OnInteractableRemoved -= OnInteractableRemoved;
        }
        
        /// <summary>
        /// Triggered when the interactable is added by a detector.
        /// </summary>
        /// <param name="interactable">The interactable that was added.</param>
        protected abstract void OnInteractableAdded(InteractableBase interactable);
        
        /// <summary>
        /// Triggered when the interactable is removed from a detector.
        /// </summary>
        /// <param name="interactable">The interactive that was removed.</param>
        protected abstract void OnInteractableRemoved(InteractableBase interactable);
    }
}
