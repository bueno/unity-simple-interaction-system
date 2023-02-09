// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.EventBase
{
    /// <summary>
    /// Inherit from it to implement commands when the detector interacts with the interactable, returning the success or failure of the interaction.
    /// </summary>
    public abstract class PostInteractionEventBase : MonoBehaviour
    {
        /// <summary> The interactable. </summary>
        protected InteractableBase InteractableBase;

        protected virtual void Awake() => InteractableBase = GetComponent<InteractableBase>();

        // Registers the abstract methods in events.
        protected virtual void OnEnable() => InteractableBase.OnInteractStart += InteractionStart;
        
        // Unsubscribes the abstract methods from events.
        protected virtual void OnDisable() => InteractableBase.OnInteractStart -= InteractionStart;

        /// <summary>
        /// Checks if the interaction happened or failed.
        /// </summary>
        /// <param name="interactableBase">The interactable who performed the action.</param>
        /// <param name="success">Return if the interactable was able to perform the action.</param>
        private void InteractionStart(InteractableBase interactableBase, bool success)
        {
            if (success)
                SuccessInteraction();
            else
                FailInteraction();
        }
        
        /// <summary>
        /// Triggered when the interactable completes the action successfully.
        /// </summary>
        protected abstract void SuccessInteraction();
        /// <summary>
        /// Triggered when the interactable does not complete the action successfully.
        /// </summary>
        protected abstract void FailInteraction();
    }
}