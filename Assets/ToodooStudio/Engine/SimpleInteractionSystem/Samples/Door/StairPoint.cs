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
    /// Responsible for designating a ladder drop location, and teleporting the player to a specific point.
    /// </summary>
    public class StairPoint : InteractableBase
    {
        [Header("Points")]
        [Tooltip("Stair drop point.")]
        [SerializeField] private Transform dropPoint;
        [Tooltip("Detector teleportation point.")]
        [SerializeField] private Transform teleportPoint;
        
        [Header("Texts")]
        [Tooltip("Text that will appear when the detector can climb the ladder.")]
        [SerializeField] private string climbStairsText;

        private bool _hasStair;
        
        protected override bool InteractBehavior(IInteractDetection detectionReceiver)
        {
            //If the script already has the ladder, teleports the detector to the teleport point
            if (_hasStair)
            {
                detectionReceiver.DetectionObject.transform.SetPositionAndRotation(teleportPoint.position, teleportPoint.rotation);
                return true;
            }
            
            //Try get the inventory.
            var stairHolder = detectionReceiver.DetectionObject.GetComponent<StairHolder>();

            if (!stairHolder)
                return false;

            if (!stairHolder.HasStair())
                return false;
            
            // Use the ladder.
            stairHolder.UseStair(dropPoint);
            _hasStair = true;
            
            // Update interaction description text.
            UpdateInteractionText(climbStairsText);
            
            return true;
        }
    }
}