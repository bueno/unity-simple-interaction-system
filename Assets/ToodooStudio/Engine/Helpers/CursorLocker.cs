// Copyright TOODOO STUDIO, LLC. All Rights Reserved.

using UnityEngine;

namespace ToodooStudio.Engine.Helpers
{
    public class CursorLocker : MonoBehaviour
    {
        [SerializeField] private bool lockOnStart = true;
        [SerializeField] private bool visible;

        private void Start()
        {
            if(lockOnStart)
                Lock();
        }

        public void Lock()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = visible;
        }
    }
}
