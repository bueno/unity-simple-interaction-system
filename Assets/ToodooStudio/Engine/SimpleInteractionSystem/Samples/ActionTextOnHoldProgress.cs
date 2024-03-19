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
    /// Responsible for updating the action text when the progress of the hold changes.
    /// </summary>
    public class ActionTextOnHoldProgress : InteractionHoldProgressEventBase
    {
        [Tooltip("When true, updates the text even if the field is blank.")]
        [SerializeField] private bool enableEmptyStrings = true;
        
        [Tooltip("Updates the interaction description text when the detector initiates the hold action.")]
        [SerializeField] private string holdStartText; 
        [Tooltip("Updates the interaction description text when the detector update maintains the action.")]
        [SerializeField] private string holdUpdateText;
        [Tooltip("Updates the interaction description text when the detector stops acting.")]
        [SerializeField] private string holdStopText;
        
        protected override void OnHoldStart(InteractableBase interactable)
        {
            if(!enableEmptyStrings && (string.IsNullOrEmpty(holdStartText) || string.IsNullOrWhiteSpace(holdStartText)))
                return;
            
            interactable.UpdateInteractionText(holdStartText);
        }

        protected override void OnHoldUpdate(InteractableBase interactable, float progressPercent)
        {
            if(!enableEmptyStrings && (string.IsNullOrEmpty(holdUpdateText) || string.IsNullOrWhiteSpace(holdUpdateText)))
                return;
            
            interactable.UpdateInteractionText(holdUpdateText);
        }

        protected override void OnHoldStop(InteractableBase interactable)
        {
            if(!enableEmptyStrings && (string.IsNullOrEmpty(holdStopText) || string.IsNullOrWhiteSpace(holdStopText)))
                return;
            
            interactable.UpdateInteractionText(holdStopText);
        }
    }
}
