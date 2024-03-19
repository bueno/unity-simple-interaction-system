/*
 MIT License

 Copyright (c) 2023+ TOODOO STUDIO LLC.

 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 SOFTWARE.
*/

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