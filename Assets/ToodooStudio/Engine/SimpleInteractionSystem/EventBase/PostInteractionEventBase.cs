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

using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.EventBase
{
    /// <summary>
    /// Inherit from it to implement commands when the detector interacts with the interactable, returning the success or failure of the interaction.
    /// </summary>
    public abstract class PostInteractionEventBase : MonoBehaviour
    {
        /// <summary> The interactable. </summary>
        protected InteractableBase InteractableBase;

        protected virtual void Awake() => InteractableBase = GetComponent<InteractableBase>();

        // Registers the abstract methods in events.
        protected virtual void OnEnable() => InteractableBase.OnInteractStart += InteractionStart;
        
        // Unsubscribes the abstract methods from events.
        protected virtual void OnDisable() => InteractableBase.OnInteractStart -= InteractionStart;

        /// <summary>
        /// Checks if the interaction happened or failed.
        /// </summary>
        /// <param name="interactableBase">The interactable who performed the action.</param>
        /// <param name="success">Return if the interactable was able to perform the action.</param>
        private void InteractionStart(InteractableBase interactableBase, bool success)
        {
            if (success)
                SuccessInteraction();
            else
                FailInteraction();
        }
        
        /// <summary>
        /// Triggered when the interactable completes the action successfully.
        /// </summary>
        protected abstract void SuccessInteraction();
        /// <summary>
        /// Triggered when the interactable does not complete the action successfully.
        /// </summary>
        protected abstract void FailInteraction();
    }
}