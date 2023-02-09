// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ToodooStudio.Engine.InteractionSystem.UI
{
    /// <summary>
    /// Responsible for mediating the manipulation of ui components in prefab.
    /// </summary>
    public class InteractionText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private Image progressImage;
        private void Awake() => descriptionText.text = "";
        
        public void SetText(string newText)
        {
            //If you have a localization system, you can get the key to the text here.
            descriptionText.text = newText;
        }

        public void UpdateHoldProgress(float percent)
        {
            progressImage.fillAmount = percent;
        }

        private void OnDisable()
        {
            UpdateHoldProgress(0f);
        }
    }
}
