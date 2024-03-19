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

using System.Collections;
using UnityEngine;

namespace ToodooStudio.Engine.SimpleInteractionSystem.Samples.UI
{
    public class CanvasGroupFade : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [Min(0)]
        [SerializeField] private float delay;
        [SerializeField] private float blend = 0.1f;
        [SerializeField] private bool disableParentObject = true;
        
        private void OnEnable()
        {
            canvasGroup.alpha = 1;
            StartCoroutine(Delay());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(delay);
            
            while (canvasGroup.alpha > 0)
            {
                yield return new WaitForEndOfFrame();
                canvasGroup.alpha -= blend * Time.deltaTime;    
            }
            
            if(disableParentObject)
                transform.parent.gameObject.SetActive(false);
        }
    }
}