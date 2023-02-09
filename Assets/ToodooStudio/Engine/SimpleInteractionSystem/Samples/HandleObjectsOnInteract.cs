// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

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
