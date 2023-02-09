// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using ToodooStudio.Engine.SimpleInteractionSystem.EventBase;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples
{
    /// <summary>
    /// Responsible for trigger animations when the detector interacts with the interactable.
    /// </summary>
    public class AnimateOnInteract : PostInteractionEventBase
    {
        [Tooltip("Interactable animator.")]
        [SerializeField] private Animator animator;
        
        [Tooltip("Name of the success animation trigger.")]
        [SerializeField] private string successTriggerName = "Open";
        [Tooltip("Name of the failure animation trigger.")]
        [SerializeField] private string failTriggerName = "Fail";
        
        /// <summary>
        /// Trigger success animation.
        /// </summary>
        protected override void SuccessInteraction()
        {
            animator.SetTrigger(successTriggerName);
        }
        
        /// <summary>
        /// Trigger failure animation.
        /// </summary>
        protected override void FailInteraction()
        {
            animator.SetTrigger(failTriggerName);
        }
    }
}