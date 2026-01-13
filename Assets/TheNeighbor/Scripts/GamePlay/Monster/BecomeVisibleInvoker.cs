using System;
using UnityEngine;

namespace Trellcko.Gameplay.Common
{
    public class BecomeVisibleInvoker : MonoBehaviour
    {
        public event Action BecameVisible;
        
        public bool IsVisible { get; private set; }
        private bool _wasInvoked;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnBecameInvisible()
        {
            IsVisible = false;
        }

        private void Update()
        {
            Debug.LogError($"{_wasInvoked} {IsVisible} {IsActuallyVisible()}");
            if (!_wasInvoked && IsVisible && IsActuallyVisible())
            {
                BecameVisible?.Invoke();
                _wasInvoked = true;
            }   
        }

        private bool IsActuallyVisible()
        {
            Vector3 dir = transform.position - _camera.transform.position;

            if (Physics.Raycast(_camera.transform.position, dir, out RaycastHit hit))
                return hit.transform == transform;

            return false;
        }
        
        private void OnBecameVisible()
        {
            _wasInvoked = false;
            IsVisible = true;
        }
    }
}
