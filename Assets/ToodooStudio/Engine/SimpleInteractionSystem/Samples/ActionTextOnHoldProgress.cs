// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using ToodooStudio.Engine.SimpleInteractionSystem.EventBase;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples
{
    /// <summary>
    /// Responsible for updating the action text when the progress of the hold changes.
    /// </summary>
    public class ActionTextOnHoldProgress : InteractionHoldProgressEventBase
    {
        [Tooltip("When true, updates the text even if the field is blank.")]
        [SerializeField] private bool enableEmptyStrings = true;
        
        [Tooltip("Updates the interaction description text when the detector initiates the hold action.")]
        [SerializeField] private string holdStartText; 
        [Tooltip("Updates the interaction description text when the detector update maintains the action.")]
        [SerializeField] private string holdUpdateText;
        [Tooltip("Updates the interaction description text when the detector stops acting.")]
        [SerializeField] private string holdStopText;
        
        protected override void OnHoldStart(InteractableBase interactable)
        {
            if(!enableEmptyStrings && (string.IsNullOrEmpty(holdStartText) || string.IsNullOrWhiteSpace(holdStartText)))
                return;
            
            interactable.UpdateInteractionText(holdStartText);
        }

        protected override void OnHoldUpdate(InteractableBase interactable, float progressPercent)
        {
            if(!enableEmptyStrings && (string.IsNullOrEmpty(holdUpdateText) || string.IsNullOrWhiteSpace(holdUpdateText)))
                return;
            
            interactable.UpdateInteractionText(holdUpdateText);
        }

        protected override void OnHoldStop(InteractableBase interactable)
        {
            if(!enableEmptyStrings && (string.IsNullOrEmpty(holdStopText) || string.IsNullOrWhiteSpace(holdStopText)))
                return;
            
            interactable.UpdateInteractionText(holdStopText);
        }
    }
}
