using Trellcko.Core.Input;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Transform _forward;
        [SerializeField] private float _speed;
        
        private IInputHandler _inputHandler;

        
        [Inject]
        private void Inject(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private void FixedUpdate()
        {
            Move(_inputHandler.GetMoveVector());
        }

        private void Move(Vector2 inputVector)
        {
            Vector3 moveVector =  (_forward.forward * inputVector.y + _forward.right * inputVector.x);

            moveVector.y = 0;
            moveVector.Normalize();
            
            _rb.MovePosition( _rb.position + _speed * Time.fixedDeltaTime * moveVector);
        }
    }
}