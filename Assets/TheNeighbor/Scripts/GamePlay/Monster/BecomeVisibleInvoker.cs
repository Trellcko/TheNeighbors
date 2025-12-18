using System;
using UnityEngine;

namespace Trellcko.Gameplay.Common
{
    public class BecomeVisibleInvoker : MonoBehaviour
    {
        public event Action BecameVisible;
        
        public bool IsVisible { get; private set; }
        
        private void OnBecameInvisible()
        {
            IsVisible = false;
        }

        private void OnBecameVisible()
        {
            IsVisible = true;
            BecameVisible?.Invoke();
        }
    }
}
