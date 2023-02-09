// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Detection
{
    /// <summary>
    /// Used by the Interactable class to detect an object that can interact with it.
    /// </summary>
    public interface IInteractDetection
    {
        /// <summary>
        /// The object responsible for detecting the interaction, useful when you want to access some component in it.
        /// </summary>
        public GameObject DetectionObject { get; set; }
    }
}