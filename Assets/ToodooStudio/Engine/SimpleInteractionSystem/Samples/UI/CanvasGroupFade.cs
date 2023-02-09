// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

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