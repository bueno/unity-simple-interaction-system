// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using ToodooStudio.Engine.SimpleInteractionSystem;
using ToodooStudio.Engine.SimpleInteractionSystem.Detection;
using ToodooStudio.Engine.SimpleInteractionSystem.Samples.Door;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples.Door
{
    /// <summary>
    /// A simple interactive stair.
    /// </summary>
    public class StairInteractable : InteractableBase
    {
        protected override bool InteractBehavior(IInteractDetection detectionReceiver)
        {
            // Try get the inventory.
            var stairHolder = detectionReceiver.DetectionObject.GetComponent<StairHolder>();

            if (!stairHolder)
                return false;
            
            // Use stair.
            stairHolder.SetStair(this);
            DisableInteract();
            return true;
        }
    }
}
