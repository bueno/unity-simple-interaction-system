// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ToodooStudio.Engine.InteractionSystem.UI
{
    /// <summary>
    /// UI manager.
    /// </summary>
    public class UIInteractionManager : UIInteractionManagerBase
    {
        [Tooltip("Interaction prefab.")]
        [SerializeField] private InteractionText interactSymbolPrefab;
        [Tooltip("Interaction gameObject parent.")]
        [SerializeField] private Transform canvasSymbolParent;
        [Tooltip("camera reference at the beginning, if null it gets the value from Camera.main")]
        [SerializeField] private Camera cameraReference;
        
        /// <summary> Icon prefabs. </summary>
        private readonly List<InteractionText> _interactSymbols = new List<InteractionText>();
        
        /// <summary> UI interactable items. </summary>
        private readonly List<IInteractableUI> _interactableItems = new List<IInteractableUI>();
       
        /// <summary> Current camera reference that the interaction icon looks at. </summary>
        private Camera _camera;

        #region UNITY METHODS

        private void Start() => SetNewCamera(cameraReference ? cameraReference : Camera.main);

        private void Update()
        {
            if(!_camera)
                return;

            if(_interactableItems.Count <= 0)
                return;
            
            for (var i = 0; i < _interactableItems.Count; i++)
            {
                // Remove disabled interactive objects.
                if (!_interactableItems[i].InteractableTransform || !_interactableItems[i].CanInteract)
                {
                    RemoveInteractable(_interactableItems[i]);
                    continue;
                }

                var currentPosition = _interactableItems[i].InteractableTransform.position;
                var newPosition = new Vector3(currentPosition.x, currentPosition.y + _interactableItems[i].OffsetY, currentPosition.z);
                
                // Move icon
                _interactSymbols[i].transform.position = _camera.WorldToScreenPoint(newPosition);
            }
        }

        #endregion

        public void SetNewCamera(Camera newCamera)
        {
            _camera = newCamera;
        }
        
        /// <summary>
        /// Add interactable to ui list.
        /// </summary>
        /// <param name="interactable">New interactable.</param>
        public override void AddInteractable(IInteractableUI interactable)
        {
            if(_interactableItems.Contains(interactable))
                return;
            
            _interactableItems.Add(interactable);
            HandleIcons();
        }

        /// <summary>
        /// Remove interactable to ui list.
        /// </summary>
        /// <param name="interactable">Old interactable.</param>
        public override void RemoveInteractable(IInteractableUI interactable)
        {
            _interactableItems.Remove(interactable);
            HandleIcons();
        }

        private void HandleIcons()
        {
            // Get icons and items count.
            var interactSymbolsCount = _interactSymbols.Count;
            var interactableItemsCount = _interactableItems.Count;
            
            // If you have more items than icons in the list.
            if (interactSymbolsCount <= interactableItemsCount)
            {
                EnableAll();

                var difference = Mathf.Abs(interactSymbolsCount - interactableItemsCount);
                
                for (var i = interactSymbolsCount; i < interactSymbolsCount + difference; i++)
                {
                    var newInteractSymbol = Instantiate(interactSymbolPrefab, canvasSymbolParent).GetComponent<InteractionText>();
                    newInteractSymbol.SetText(_interactableItems[i].ActionText);
                    
                    _interactSymbols.Add(newInteractSymbol);
                }
                    
            }
            // If you have more icons than items in the list.
            else if (interactSymbolsCount > interactableItemsCount)
            {
                DisableAll();

                for (var i = 0; i < interactableItemsCount; i++)
                {
                    _interactSymbols[i].gameObject.SetActive(true);

                    if(interactSymbolsCount > i)
                        _interactSymbols[i].SetText(_interactableItems[i].ActionText);
                }
            }
        }

        /// <summary>
        /// Enable all icons and update texts.
        /// </summary>
        private void EnableAll()
        {
            foreach (var symbol in _interactSymbols)
                symbol.gameObject.SetActive(true);

            for (var i = 0; i < _interactSymbols.Count; i++)
            {
                if(_interactSymbols.Count > i)
                    _interactSymbols[i].SetText(_interactableItems[i].ActionText);
            }
        }
        
        /// <summary>
        /// Disable all icons.
        /// </summary>
        private void DisableAll()
        {
            foreach (var symbol in _interactSymbols)
                symbol.gameObject.SetActive(false);

            foreach (var interactionText in _interactSymbols)
                interactionText.SetText("");
        }

        //Destroy prefabs and clear all lists
        public void ClearAll()
        {
            for (var i = _interactSymbols.Count -1; i >= 0; i--)
                Destroy(_interactSymbols[i].gameObject);

            _interactSymbols.Clear();
            _interactableItems.Clear();
        }

        /// <summary>
        /// Update icons texts.
        /// </summary>
        /// <param name="interactableUI">The object with the IInteractableUI interface.</param>
        public override void UpdateText(IInteractableUI interactableUI)
        {
            var index = FindInteractableIndex(interactableUI);
            
            if(index < 0)
                return;
            
            _interactSymbols[index].SetText(_interactableItems[index].ActionText);
        }

        /// <summary>
        /// It is used to inform the user interface about the progress of the hold.
        /// </summary>
        /// <param name="interactableUI">The object with the IInteractableUI interface.</param>
        /// <param name="percent">Percent of progress.</param>
        public override void UpdateHoldProgress(IInteractableUI interactableUI, float percent)
        {
            var index = FindInteractableIndex(interactableUI);
            
            if(index < 0)
                return;
            
            _interactSymbols[index].UpdateHoldProgress(percent);
        }
        
        /// <summary>
        /// Try to find the item by hashcode, if it fails it returns -1.
        /// </summary>
        /// <param name="interactableUI">The object with the IInteractableUI interface.</param>
        /// <returns></returns>
        private int FindInteractableIndex(IInteractableUI interactableUI) => _interactableItems.FindIndex(ui => ui.GetHashCode() == interactableUI.GetHashCode());
    }
}
