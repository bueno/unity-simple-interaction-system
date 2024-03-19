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

namespace ToodooStudio.Engine.SimpleInteractionSystem.InteractionInput
{
    /// <summary>
    /// Reference the inputs to the interaction system.
    /// This class uses the old input system, but you can integrate the new input
    /// or your own input through the InputReferenceBase class.
    /// </summary>
    public class InteractInputReference : InputReferenceBase
    {
        [SerializeField] private KeyCode keyboardKey = KeyCode.E;
        [SerializeField] private KeyCode mouseKey = KeyCode.Mouse0;

        private void Update()
        {
            KeyboardDownPressed = Input.GetKeyDown(keyboardKey);
            MouseDownPressed = Input.GetKeyDown(mouseKey);

            KeyboardHoldPressed = Input.GetKey(keyboardKey);
            MouseHoldPressed = Input.GetKey(mouseKey);
        }
    }
}
