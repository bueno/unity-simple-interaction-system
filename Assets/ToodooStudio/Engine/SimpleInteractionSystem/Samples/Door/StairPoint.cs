// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

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