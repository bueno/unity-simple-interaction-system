// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using ToodooStudio.Engine.SimpleInteractionSystem.Detection;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples.Door
{
    /// <summary>
    /// A simple interactive key.
    /// </summary>
    public class SimpleKey : InteractableBase
    {
        [Tooltip("Key data.")]
        public KeyScriptable keyScriptableData;
        
        protected override bool InteractBehavior(IInteractDetection detectionReceiver)
        {
            //Try get the inventory.
            var keyHolder = detectionReceiver.DetectionObject.GetComponent<KeyHolder>();

            if (!keyHolder)
                return false;
            
            //Set this key to inventory.
            keyHolder.SetKey(this);
            DisableInteract();
            return true;
        }
    }
}