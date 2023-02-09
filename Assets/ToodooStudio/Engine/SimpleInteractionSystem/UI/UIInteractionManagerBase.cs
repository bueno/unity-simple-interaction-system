// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.InteractionSystem.UI
{
    /// <summary>
    /// UI interaction manager base class. If you want to make your own logic, inherit from this class.
    /// </summary>
    public abstract class UIInteractionManagerBase : MonoBehaviour
    {
        /// <summary>
        /// Update icons texts.
        /// </summary>
        public abstract void UpdateText(IInteractableUI interactableUI);
        /// <summary>
        /// Add interactable to ui list.
        /// </summary>
        /// <param name="interactableUI">New interactable.</param>
        public abstract void AddInteractable(IInteractableUI interactableUI);
        /// <summary>
        /// Remove interactable elements from the ui list.
        /// </summary>
        /// <param name="interactableUI">Old interactable.</param>
        public abstract void RemoveInteractable(IInteractableUI interactableUI);

        /// <summary>
        /// It is used to inform the user interface about the progress of the hold.
        /// </summary>
        /// <param name="interactableUI">The object that detected the interactable.</param>
        /// <param name="percent">Percent of progress.</param>
        public abstract void UpdateHoldProgress(IInteractableUI interactableUI, float percent);
    }
}