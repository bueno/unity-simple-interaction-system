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
    /// Responsible for updating the interaction description when the interactable is added to or removed from the detector.
    /// </summary>
    public class ActionTextOnAddOrRemoveInteract : AddOrRemoveInteractableEventBase 
    {
        [Tooltip("When true, updates the text even if the field is blank.")]
        [SerializeField] private bool enableEmptyStrings = true;
        
        [Tooltip("Updates the interaction description text when the interactable is added by a detector with this text.")]
        [SerializeField] private string onAddText;
        
        [Tooltip("Updates the interaction description text when the interactable is removed from a detector with this text.")]
        [SerializeField] private string onRemoveText;

        [Tooltip("Does the user interface need to be updated when the interactive object is removed?")]
        [SerializeField] private bool forceUiUpdateOnRemove;
        
        /// <summary>
        /// Updates the text when the interactable is added by a detector.
        /// </summary>
        /// <param name="interactable">The interactable that was added.</param>
        protected override void OnInteractableAdded(InteractableBase interactable)
        {
            if(!enableEmptyStrings && (string.IsNullOrEmpty(onAddText) || string.IsNullOrWhiteSpace(onAddText)))
                return;
            
            InteractableBase.UpdateInteractionText(onAddText);
        }
        
        /// <summary>
        /// Updates the text when the interactable is removed from a detector.
        /// </summary>
        /// <param name="interactable">The interactable that was removed.</param>
        protected override void OnInteractableRemoved(InteractableBase interactable)
        {
            if(!enableEmptyStrings && (string.IsNullOrEmpty(onRemoveText) || string.IsNullOrWhiteSpace(onRemoveText)))
                return;
            
            InteractableBase.UpdateInteractionText(onRemoveText, forceUiUpdateOnRemove);
        }
    }
}
