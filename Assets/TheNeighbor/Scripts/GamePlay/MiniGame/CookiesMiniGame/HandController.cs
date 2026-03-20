using System;
using Trellcko.Core.Input;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.MiniGame
{
    public class HandController : MonoBehaviour
    {
        [SerializeField] private Vector3 _handStartPosition;
        [SerializeField] private float _sensitivity = 40;
        [SerializeField] private Vector2 _zLocalBounds;

        private event Action<bool> CookieGot;
        
        private IInputHandler _inputHandler;

        [Inject]
        private void Construct(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }


        private void Update()
        {
            Vector3 mouseDelta = _inputHandler.GetMouseDelta();
            mouseDelta *= _sensitivity * Time.deltaTime * -1;
            mouseDelta.y = 0;
            
            Vector3 newPosition = transform.position + mouseDelta;
            newPosition = transform.parent.InverseTransformPoint(newPosition);
            newPosition.z  = Mathf.Clamp(newPosition.z, _zLocalBounds.x, _zLocalBounds.y);
            
            transform.localPosition = newPosition;
        }

        public void Reset()
        {
            transform.localPosition = _handStartPosition;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Cookie cookie))
            {
                CookieGot?.Invoke(cookie.IsGood);
                Destroy(cookie.gameObject);
            }
        }
    }
}