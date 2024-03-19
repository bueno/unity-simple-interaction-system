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
    /// Inherit from this class to implement behaviors related to interactive objects of type hold.
    /// </summary>
    public abstract class InteractionHoldProgressEventBase : MonoBehaviour
    {
        protected InteractableBase InteractableBase;
        
        private void Awake()
        {
            InteractableBase = GetComponent<InteractableBase>();
        }

        private void OnEnable()
        {
            InteractableBase.OnHoldUpdateStart += OnHoldStart;
            InteractableBase.OnHoldUpdateProgress += OnHoldUpdate;
            InteractableBase.OnHoldUpdateStop += OnHoldStop;
        }

        private void OnDisable()
        {
            InteractableBase.OnHoldUpdateStart -= OnHoldStart;
            InteractableBase.OnHoldUpdateProgress -= OnHoldUpdate;
            InteractableBase.OnHoldUpdateStop -= OnHoldStop;
        }

        /// <summary>
        /// Called when the holding progress begins.
        /// </summary>
        /// <param name="interactable">The object of the interactivity.</param>
        protected abstract void OnHoldStart(InteractableBase interactable);

        /// <summary>
        /// Called when the holding progress update.
        /// </summary>
        /// <param name="interactable">The object of the interactivity.</param>
        /// <param name="progressPercent">The current progress in percent.</param>
        protected abstract void OnHoldUpdate(InteractableBase interactable, float progressPercent);

        /// <summary>
        /// Called when the holding progress stops.
        /// </summary>
        /// <param name="interactable">The object of the interactivity.</param>
        protected abstract void OnHoldStop(InteractableBase interactable);
    }
}
