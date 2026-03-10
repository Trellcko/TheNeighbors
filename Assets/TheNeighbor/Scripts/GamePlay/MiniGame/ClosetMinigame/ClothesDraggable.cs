using Trellcko.Core.Input;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.MiniGame
{
    public class ClothesDraggable : MonoBehaviour
    {
        private Camera _camera;
        private Plane _dragPlane;
        private IInputHandler _inputHandler;

        [Inject]
        private void Construct(IInputHandler handler)
        {
            _inputHandler = handler;
        }
        
        private void Awake()
        {
            _camera = Camera.main;
            _dragPlane = new Plane(Vector3.up, transform.position);
        }

        private void Update()
        {
            Vector2 mousePosition = _inputHandler.GetMousePosition();

            Ray ray = _camera.ScreenPointToRay(mousePosition);

            if (_dragPlane.Raycast(ray, out float distance))
            {
                Vector3 point = ray.GetPoint(distance);
                transform.position = point;
            }
        }
    }
}