using ToodooStudio.Engine.SimpleInteractionSystem.EventBase;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples
{
    public class DebugOnInteract : PostInteractionEventBase
    {
        protected override void FailInteraction()
        {
            Debug.Log("Fail");
        }

        protected override void SuccessInteraction()
        {
            Debug.Log("Success!");
        }
    }
}
