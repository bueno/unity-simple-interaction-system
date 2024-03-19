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
