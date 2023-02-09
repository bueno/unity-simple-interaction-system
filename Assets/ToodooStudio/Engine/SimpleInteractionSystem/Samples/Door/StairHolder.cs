// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples.Door
{
    /// <summary>
    /// It is used to simulate a inventory. Stores only the ladder.
    /// </summary>
    public class StairHolder : MonoBehaviour
    {
        [Tooltip("Character's hand")]
        [SerializeField] private Transform hand;
        private StairInteractable _currentStair;

        /// <summary>
        /// Updates the current stair to the new stair.
        /// </summary>
        /// <param name="newStair">The new stair.</param>
        public void SetStair(StairInteractable newStair)
        {
            // If a stair already exists, removes the previous stair.
            if (_currentStair)
            {
                _currentStair.transform.SetParent(null);
                _currentStair = null;
            }

            if(!newStair)
                return;
            
            // Set new stair.
            _currentStair = newStair;
            var stairTransform = _currentStair.transform;
            
            // Set parent and position
            stairTransform.SetParent(hand);
            _currentStair.transform.localPosition = Vector3.zero;
        }
        
        /// <summary>
        /// Use current stair on inventory.
        /// </summary>
        /// <param name="dropPosition">A place to drop the ladder.</param>
        public void UseStair(Transform dropPosition)
        {
            _currentStair.transform.SetPositionAndRotation(dropPosition.position, dropPosition.rotation);
            SetStair(null);
        }

        /// <summary>
        /// Checks if holder class has a ladder.
        /// </summary>
        public bool HasStair() => _currentStair;
    }
}
