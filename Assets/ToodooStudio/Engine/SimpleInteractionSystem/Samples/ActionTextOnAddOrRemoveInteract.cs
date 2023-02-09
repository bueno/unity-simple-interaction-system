// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using ToodooStudio.Engine.SimpleInteractionSystem.EventBase;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples
{
    /// <summary>
    /// Responsible for updating the interaction description when the interactable is added to or removed from the detector.
    /// </summary>
    public class ActionTextOnAddOrRemoveInteract : AddOrRemoveInteractableEventBase 
    {
        [Tooltip("When true, updates the text even if the field is blank.")]
        [SerializeField] private bool enableEmptyStrings = true;
        
        [Tooltip("Updates the interaction description text when the interactable is added by a detector with this text.")]
        [SerializeField] private string onAddText;
        
        [Tooltip("Updates the interaction description text when the interactable is removed from a detector with this text.")]
        [SerializeField] private string onRemoveText;

        [Tooltip("Does the user interface need to be updated when the interactive object is removed?")]
        [SerializeField] private bool forceUiUpdateOnRemove;
        
        /// <summary>
        /// Updates the text when the interactable is added by a detector.
        /// </summary>
        /// <param name="interactable">The interactable that was added.</param>
        protected override void OnInteractableAdded(InteractableBase interactable)
        {
            if(!enableEmptyStrings && (string.IsNullOrEmpty(onAddText) || string.IsNullOrWhiteSpace(onAddText)))
                return;
            
            InteractableBase.UpdateInteractionText(onAddText);
        }
        
        /// <summary>
        /// Updates the text when the interactable is removed from a detector.
        /// </summary>
        /// <param name="interactable">The interactable that was removed.</param>
        protected override void OnInteractableRemoved(InteractableBase interactable)
        {
            if(!enableEmptyStrings && (string.IsNullOrEmpty(onRemoveText) || string.IsNullOrWhiteSpace(onRemoveText)))
                return;
            
            InteractableBase.UpdateInteractionText(onRemoveText, forceUiUpdateOnRemove);
        }
    }
}
