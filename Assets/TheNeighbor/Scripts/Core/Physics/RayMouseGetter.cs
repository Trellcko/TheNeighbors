using Trellcko.Core.Input;
using UnityEngine;

namespace Trellcko.Core.Physics
{
    public class RayMouseGetter : IRayGetter
    {
        private readonly IInputHandler _inputHandler;
        private readonly Camera _camera;

        public RayMouseGetter(IInputHandler inputHandler, Camera camera)
        {
            _inputHandler = inputHandler;
            _camera = camera;
        }
        
        public Ray GetRay() => 
            _camera.ScreenPointToRay(_inputHandler.GetMousePosition());
    }
}