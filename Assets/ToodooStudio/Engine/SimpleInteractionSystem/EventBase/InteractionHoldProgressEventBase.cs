// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.EventBase
{
    /// <summary>
    /// Inherit from this class to implement behaviors related to interactive objects of type hold.
    /// </summary>
    public abstract class InteractionHoldProgressEventBase : MonoBehaviour
    {
        protected InteractableBase InteractableBase;
        
        private void Awake()
        {
            InteractableBase = GetComponent<InteractableBase>();
        }

        private void OnEnable()
        {
            InteractableBase.OnHoldUpdateStart += OnHoldStart;
            InteractableBase.OnHoldUpdateProgress += OnHoldUpdate;
            InteractableBase.OnHoldUpdateStop += OnHoldStop;
        }

        private void OnDisable()
        {
            InteractableBase.OnHoldUpdateStart -= OnHoldStart;
            InteractableBase.OnHoldUpdateProgress -= OnHoldUpdate;
            InteractableBase.OnHoldUpdateStop -= OnHoldStop;
        }

        /// <summary>
        /// Called when the holding progress begins.
        /// </summary>
        /// <param name="interactable">The object of the interactivity.</param>
        protected abstract void OnHoldStart(InteractableBase interactable);

        /// <summary>
        /// Called when the holding progress update.
        /// </summary>
        /// <param name="interactable">The object of the interactivity.</param>
        /// <param name="progressPercent">The current progress in percent.</param>
        protected abstract void OnHoldUpdate(InteractableBase interactable, float progressPercent);

        /// <summary>
        /// Called when the holding progress stops.
        /// </summary>
        /// <param name="interactable">The object of the interactivity.</param>
        protected abstract void OnHoldStop(InteractableBase interactable);
    }
}
