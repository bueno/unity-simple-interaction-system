// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ToodooStudio.Engine.InteractionSystem.UI
{
    /// <summary>
    /// UI manager for fps demo.
    /// </summary>
    public class UIInteractionManagerFPS : UIInteractionManagerBase
    {
        [Tooltip("The cursor's image.")]
        [SerializeField] private Image cursorImage;
        [Tooltip("The image responsible for showing the progress of the holding action.")]
        [SerializeField] private Image holdProgressImage;
        [Tooltip("Description of the interaction action at ui.")]
        [SerializeField] private TextMeshProUGUI interactableActionText;
        
        [Tooltip("Default cursor size.")]
        [SerializeField] private float defaultSize = 30;
        [Tooltip("Cursor size when there is an interactive object.")]
        [SerializeField] private float interactSize = 50;
        
        [Tooltip("Default cursor sprite.")]
        [SerializeField] private Sprite cursorSpriteDefault;
        [Tooltip("Cursor sprite when there is an interactive object.")]
        [SerializeField] private Sprite cursorSpriteInteract;
        
        private IInteractableUI _currentInteractableUI;

        private void Start()
        {
            SetToDefaultCursor();
            holdProgressImage.fillAmount = 0f;
        }

        /// <summary>
        /// Add interactable to ui list.
        /// </summary>
        /// <param name="interactableUI">New interactable.</param>
        public override void AddInteractable(IInteractableUI interactableUI)
        {
            cursorImage.sprite = cursorSpriteInteract;
            cursorImage.rectTransform.sizeDelta = Vector2.one * interactSize;

            interactableActionText.text = interactableUI.ActionText;

            _currentInteractableUI = interactableUI;
        }

        /// <summary>
        /// Remove interactable to ui list.
        /// </summary>
        /// <param name="interactableUI">Old interactable.</param>
        public override void RemoveInteractable(IInteractableUI interactableUI)
        {
            SetToDefaultCursor();
            holdProgressImage.fillAmount = 0f;
            _currentInteractableUI = null;
        }
        
        /// <summary>
        /// Update icons texts.
        /// </summary>
        /// <param name="interactableUI">The object with the IInteractableUI interface.</param>
        public override void UpdateText(IInteractableUI interactableUI)
        {
            if(_currentInteractableUI != null)
                interactableActionText.text = interactableUI.ActionText;
        }

        /// <summary>
        /// It is used to inform the user interface about the progress of the hold.
        /// </summary>
        /// <param name="interactableUI">The object with the IInteractableUI interface.</param>
        /// <param name="percent">Percent of progress.</param>
        public override void UpdateHoldProgress(IInteractableUI interactableUI, float percent)
        {
            holdProgressImage.fillAmount = percent;
        }

        /// <summary>
        /// Reset the cursor. 
        /// </summary>
        private void SetToDefaultCursor()
        {
            cursorImage.sprite = cursorSpriteDefault;
            cursorImage.rectTransform.sizeDelta = Vector2.one * defaultSize;

            interactableActionText.text = "";
        }
    }
}
