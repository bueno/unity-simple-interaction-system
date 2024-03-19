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

namespace ToodooStudio.Engine.SimpleInteractionSystem.UI
{
    /// <summary>
    /// UI interaction manager base class. If you want to make your own logic, inherit from this class.
    /// </summary>
    public abstract class UIInteractionManagerBase : MonoBehaviour
    {
        /// <summary>
        /// Update icons texts.
        /// </summary>
        public abstract void UpdateText(IInteractableUI interactableUI);
        /// <summary>
        /// Add interactable to ui list.
        /// </summary>
        /// <param name="interactableUI">New interactable.</param>
        public abstract void AddInteractable(IInteractableUI interactableUI);
        /// <summary>
        /// Remove interactable elements from the ui list.
        /// </summary>
        /// <param name="interactableUI">Old interactable.</param>
        public abstract void RemoveInteractable(IInteractableUI interactableUI);

        /// <summary>
        /// It is used to inform the user interface about the progress of the hold.
        /// </summary>
        /// <param name="interactableUI">The object that detected the interactable.</param>
        /// <param name="percent">Percent of progress.</param>
        public abstract void UpdateHoldProgress(IInteractableUI interactableUI, float percent);
    }
}