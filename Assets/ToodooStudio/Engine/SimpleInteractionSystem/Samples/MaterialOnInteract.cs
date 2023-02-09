// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using ToodooStudio.Engine.SimpleInteractionSystem.EventBase;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples
{
    /// <summary>
    /// Responsible for updating materials when the detector interacts with the interactable.
    /// </summary>
    public class MaterialOnInteract : PostInteractionEventBase
    {
        [SerializeField] private Renderer mRenderer;
        [Tooltip("Material when the action is successful.")]
        [SerializeField] private Material successMaterial;
        [Tooltip("Material when the action fails.")]
        [SerializeField] private Material failMaterial;

        /// <summary>
        /// Updates material when the action succeeds.
        /// </summary>
        protected override void SuccessInteraction()
        {
            mRenderer.material = successMaterial;
        }

        /// <summary>
        /// Updates material when the action fails.
        /// </summary>
        protected override void FailInteraction()
        {
            mRenderer.material = failMaterial;
        }
    }
}
