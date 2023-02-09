// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

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