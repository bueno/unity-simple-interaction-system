// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.InteractionSystem.UI
{
    /// <summary>
    /// All interactive objects that inherit from this interface can be added to the ui
    /// </summary>
    public interface IInteractableUI
    {
        /// <summary> Interaction description. </summary>
        string ActionText { get; set; }
        
        /// <summary> It is used as a reference point for the ui. </summary>
        Transform InteractableTransform { get; set; }
        
        /// <summary> Checks if interactable is active. </summary>
        bool CanInteract { get; set; }
        
        /// <summary> UI offset on Y axis. </summary>
        float OffsetY { get; set; }
    }
}