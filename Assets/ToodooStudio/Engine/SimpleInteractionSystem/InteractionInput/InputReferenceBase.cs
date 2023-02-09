// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.InteractionInput
{
    /// <summary>
    /// Input reference base. It is used by the interaction system to perform the actions.
    /// </summary>
    public class InputReferenceBase : MonoBehaviour
    {
        /// <summary> Input.GetKeyDown(keyboardKey). </summary>
        public bool KeyboardDownPressed { get; protected set; }
        
        /// <summary> Input.GetKey(keyboardKey). </summary>
        public bool KeyboardHoldPressed { get; protected set; }
        
        /// <summary> Input.GetKeyDown(mouseKey). </summary>
        public bool MouseDownPressed { get; protected set; }
        
        /// <summary> Input.GetKey(mouseKey). </summary>
        public bool MouseHoldPressed { get; protected set; }
    }
}