// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using ToodooStudio.Engine.SimpleInteractionSystem.Detection;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples.Door
{
    /// <summary>
    /// Simple interaction class example.
    /// </summary>
    public class SimpleInteractableExample : InteractableBase
    {
        [Tooltip("If true, disables the interactable after the action.")]
        [SerializeField] private bool disableInteraction;
        
        protected override bool InteractBehavior(IInteractDetection detectionReceiver)
        {
            if(disableInteraction)
                DisableInteract();
            
            return true;
        }
    }
}
