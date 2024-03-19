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

using ToodooStudio.Engine.SimpleInteractionSystem.Detection;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples.Door
{
    /// <summary>
    /// Simple interaction class example.
    /// </summary>
    public class SimpleInteractableExample : InteractableBase
    {
        [Tooltip("If true, disables the interactable after the action.")]
        [SerializeField] private bool disableInteraction;
        
        protected override bool InteractBehavior(IInteractDetection detectionReceiver)
        {
            if(disableInteraction)
                DisableInteract();
            
            return true;
        }
    }
}
