// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

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
