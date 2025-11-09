using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Trellcko.Core.Input
{
    public class InputHandler : IInputHandler, IDisposable
    {
        private readonly InputSystemActions _actions = new();

        public Vector2 GetMoveVector() => _actions.Player.Move.ReadValue<Vector2>();
        public Vector2 GetMouseDelta() => _actions.Player.Rotation.ReadValue<Vector2>();
        public event Action<Vector2> Moved;
        public event Action MovedCanceled;
        public event Action<Vector2> MouseMoved;
        public event Action Interacted;

        public InputHandler()
        {
            _actions.Enable();
            _actions.Player.Rotation.performed += OnRotationPerformed;
            _actions.Player.Move.performed += OnMovePerformed;
            _actions.Player.Move.canceled += OnMoveCanceled;
            _actions.Player.Interact.performed += OnInteracted;
        }

        public void Dispose()
        {
            _actions.Player.Move.performed -= OnMovePerformed;
            _actions.Player.Rotation.performed -= OnRotationPerformed;
            _actions.Player.Move.canceled -= OnMoveCanceled;
            _actions.Player.Interact.performed -= OnInteracted;
        }

        private void OnInteracted(InputAction.CallbackContext obj)
        {
            Interacted?.Invoke();
        }

        private void OnMoveCanceled(InputAction.CallbackContext obj)
        {
            MovedCanceled?.Invoke();
        }

        private void OnMovePerformed(InputAction.CallbackContext obj)
        {
            Moved?.Invoke(obj.ReadValue<Vector2>());
        }

        private void OnRotationPerformed(InputAction.CallbackContext obj)
        {
            MouseMoved?.Invoke(obj.ReadValue<Vector2>());
        }
    }
}