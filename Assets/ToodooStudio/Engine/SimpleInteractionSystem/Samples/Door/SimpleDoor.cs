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
    /// A simple interactive door. The animation is performed externally.
    /// </summary>
    public class SimpleDoor : InteractableBase
    {
        [Tooltip("Requirement to open the door, if null the door does not need a key to open.")]
        [SerializeField] private KeyScriptable requiredKeyScriptable;
        [Tooltip("Will the key be lost with use?")]
        [SerializeField] private bool destroyKey = true;

        protected override bool InteractBehavior(IInteractDetection detectionReceiver)
        {
            // If the door doesn't need the key, it just deactivates the interaction and returns that the interaction was successful.
            if (!requiredKeyScriptable)
            {
                DisableInteract();
                return true;
            }
            
            // Try get the inventory.
            var keyHolder = detectionReceiver.DetectionObject.GetComponent<KeyHolder>();

            if (!keyHolder)
                return false;
            
            // Checks if the player has the key.
            var success = keyHolder.CompareKey(requiredKeyScriptable);

            if (!success) 
                return false;
            
            // Use the key and disable interaction.
            keyHolder.UseCurrentKey(false, destroyKey);
            DisableInteract();

            return true;
        }
    }
}
