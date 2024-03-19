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
