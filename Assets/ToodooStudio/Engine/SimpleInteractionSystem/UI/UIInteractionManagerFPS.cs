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

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ToodooStudio.Engine.SimpleInteractionSystem.UI
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
