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

using System;
using System.Collections.Generic;
using ToodooStudio.Engine.SimpleInteractionSystem.EventBase;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples
{
    [Serializable]
    public class GameObjectHandler
    {
        public GameObject gObject;
        public bool setActive;
    }
    
    /// <summary>
    /// Responsible for activating or deactivating objects when the detector interacts with the interactable.
    /// </summary>
    public class HandleObjectsOnInteract : PostInteractionEventBase
    {
        [Tooltip("Objects that will change when the interaction succeeds.")]
        [SerializeField] private List<GameObjectHandler> successList;
        [Tooltip("Objects that will change when the interaction fails.")]
        [SerializeField] private List<GameObjectHandler> failList;
        
        /// <summary>
        /// Updates gameObjects when the action succeeds.
        /// </summary>
        protected override void SuccessInteraction()
        {
            foreach (var handler in successList)
                handler.gObject.SetActive(handler.setActive);
        }
        
        /// <summary>
        /// Updates gameObjects when the action fails.
        /// </summary>
        protected override void FailInteraction()
        {
            foreach (var handler in failList)
                handler.gObject.SetActive(handler.setActive);
        }
    }
}
