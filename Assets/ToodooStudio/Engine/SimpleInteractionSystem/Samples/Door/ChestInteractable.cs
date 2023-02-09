// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using ToodooStudio.Engine.SimpleInteractionSystem.Detection;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples.Door
{
    /// <summary>
    /// Simple chest.
    /// </summary>
    public class ChestInteractable : InteractableBase
    {
        private bool _firstTime = true;
        protected override bool InteractBehavior(IInteractDetection detectionReceiver)
        {
            if (!_firstTime)
                return false;
        
            //animator.SetTrigger(triggerName);
            _firstTime = false;
            return true;
        }
    }
}
