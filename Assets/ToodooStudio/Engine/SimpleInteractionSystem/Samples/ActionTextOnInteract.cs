// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using ToodooStudio.Engine.SimpleInteractionSystem.EventBase;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples
{
    /// <summary>
    /// Responsible for updating the interaction description when the detector interacts with the interactable.
    /// </summary>
    public class ActionTextOnInteract : PostInteractionEventBase
    {
        [Tooltip("When true, updates the text even if the field is blank.")]
        [SerializeField] private bool enableEmptyStrings = true;
        
        [Tooltip("Updates the interaction description text when the action was successful with this text.")]
        [SerializeField] private string successText;
        [Tooltip("Updates the interaction description text when the action failed with this text.")]
        [SerializeField] private string failText;
        
        /// <summary>
        /// Updates the interaction description text when the action was successful.
        /// </summary>
        protected override void SuccessInteraction()
        {
            if(!enableEmptyStrings && (string.IsNullOrEmpty(successText) || string.IsNullOrWhiteSpace(successText)))
                return;
            
            InteractableBase.UpdateInteractionText(successText);
        }

        /// <summary>
        /// Updates the interaction description text when the action failed.
        /// </summary>
        protected override void FailInteraction()
        {
            if(!enableEmptyStrings && (string.IsNullOrEmpty(failText) || string.IsNullOrWhiteSpace(failText)))
                return;
            
            InteractableBase.UpdateInteractionText(failText);
        }
    }
}
