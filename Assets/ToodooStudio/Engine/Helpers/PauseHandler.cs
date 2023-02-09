// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.Helpers
{
    public class PauseHandler : MonoBehaviour
    {
        [SerializeField] private bool pauseOnEnable;
        [SerializeField] private bool resumeOnDisable;
        
        private void OnEnable()
        {
            if(pauseOnEnable)
                Time.timeScale = 0;
        }

        private void OnDisable()
        {
            if(resumeOnDisable)
                Time.timeScale = 1;
        }
    }
}
