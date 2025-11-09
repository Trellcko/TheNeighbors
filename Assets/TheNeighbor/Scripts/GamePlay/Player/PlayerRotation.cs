using System;
using Trellcko.Core.Input;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 200f;
        [SerializeField] private float _maxPitch = 10f;
        
        public bool IsEnabled { get; set; } = true;
        
        private float _currentPitch = 0f;
        private IInputHandler _input;
        private float _totalY;

        [Inject]
        private void Inject(IInputHandler inputHandler)
        {
            _input = inputHandler;
        }

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if(IsEnabled)
                Look(_input.GetMouseDelta());
        }

        private void OnMouseMoved(Vector2 mouseDelta)
        {
            Look(mouseDelta);
        }

        private void Look(Vector2 mouseDelta)
        {
            mouseDelta *= _sensitivity * Time.deltaTime;

            _totalY += mouseDelta.x;

            _currentPitch -= mouseDelta.y;
            _currentPitch = Mathf.Clamp(_currentPitch, -_maxPitch, _maxPitch);
            transform.rotation = Quaternion.Euler(_currentPitch, _totalY, 0f);
        }
    }
}