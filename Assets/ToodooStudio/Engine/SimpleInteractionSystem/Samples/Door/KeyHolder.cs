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
    /// It is used to simulate a inventory. Stores only the key.
    /// </summary>
    public class KeyHolder : MonoBehaviour
    {
        [Tooltip("Character's hand")]
        [SerializeField] private Transform hand;
        private SimpleKey _currentKey;

        /// <summary>
        /// Updates the current key to the new key.
        /// </summary>
        /// <param name="newKey">The new key.</param>
        public void SetKey(SimpleKey newKey)
        {
            // If a key already exists, removes the previous key.
            if (_currentKey)
            {
                _currentKey.transform.SetParent(null);
                _currentKey = null;
            }

            if(!newKey)
                return;
            
            // Set new key.
            _currentKey = newKey;
            var keyTransform = _currentKey.transform;
            
            // Set parent and position
            keyTransform.SetParent(hand);
            keyTransform.localPosition = Vector3.zero;
        }

        /// <summary>
        /// Checks if the previous key is equal to the one in the parameter.
        /// </summary>
        /// <param name="keyScriptable">Key for comparing.</param>
        /// <returns>Is Equals?</returns>
        public bool CompareKey(KeyScriptable keyScriptable)
        {
            if (!_currentKey)
                return false;
            
            return _currentKey.keyScriptableData == keyScriptable;
        }

        /// <summary>
        /// Use current key on inventory.
        /// </summary>
        /// <param name="nullParent">Set parent as null?</param>
        /// <param name="destroy">Destroy old key?</param>
        public void UseCurrentKey(bool nullParent = true, bool destroy = true)
        {
            if(destroy)
                Destroy(_currentKey.gameObject);
            
            if(nullParent)
                SetKey(null);
        }
    }
}