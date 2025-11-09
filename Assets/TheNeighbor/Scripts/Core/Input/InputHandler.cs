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
        public event Action<Vector2> MouseMoved;

        public InputHandler()
        {
            _actions.Enable();
            _actions.Player.Rotation.performed += OnPerformed;
        }

        public void Dispose()
        {
            _actions.Player.Rotation.performed -= OnPerformed;
        }

        private void OnPerformed(InputAction.CallbackContext obj)
        {
            MouseMoved?.Invoke(obj.ReadValue<Vector2>());
        }
    }
}