// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using ToodooStudio.Engine.SimpleInteractionSystem.Detection;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples.Door
{
    /// <summary>
    /// A simple interactive door. The animation is performed externally.
    /// </summary>
    public class SimpleDoor : InteractableBase
    {
        [Tooltip("Requirement to open the door, if null the door does not need a key to open.")]
        [SerializeField] private KeyScriptable requiredKeyScriptable;
        [Tooltip("Will the key be lost with use?")]
        [SerializeField] private bool destroyKey = true;

        protected override bool InteractBehavior(IInteractDetection detectionReceiver)
        {
            // If the door doesn't need the key, it just deactivates the interaction and returns that the interaction was successful.
            if (!requiredKeyScriptable)
            {
                DisableInteract();
                return true;
            }
            
            // Try get the inventory.
            var keyHolder = detectionReceiver.DetectionObject.GetComponent<KeyHolder>();

            if (!keyHolder)
                return false;
            
            // Checks if the player has the key.
            var success = keyHolder.CompareKey(requiredKeyScriptable);

            if (!success) 
                return false;
            
            // Use the key and disable interaction.
            keyHolder.UseCurrentKey(false, destroyKey);
            DisableInteract();

            return true;
        }
    }
}
