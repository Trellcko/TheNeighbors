using System;
using Trellcko.Core.Input;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.Player
{
    public class PlayerInteractable : MonoBehaviour
    {
        [SerializeField] private float _rayLength;
        
        private IInputHandler _inputHandler;

        private Camera _camera;

        private QuestInteractable _lastInteractable;

        private readonly RaycastHit[] _hits = new RaycastHit[5];

        [Inject]
        private void Inject(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private void OnEnable()
        {
            _inputHandler.MouseMoved += OnMoveInputInvoked;
            _inputHandler.Moved += OnMoveInputInvoked;
            _inputHandler.Interacted += OnInteractButtonClicked;
        }

        private void OnDisable()
        {
            _inputHandler.MouseMoved -= OnMoveInputInvoked;
            _inputHandler.Moved -= OnMoveInputInvoked;
            _inputHandler.Interacted -= OnInteractButtonClicked;
        }

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnMoveInputInvoked(Vector2 obj)
        {
            CheckForSelectables();
        }

        private void CheckForSelectables()
        {
            if (_lastInteractable)
            {
                _lastInteractable.DisableSelectOutline();
            }
            if (TryGetInteractable(out QuestInteractable questInteractable))
            {
                if (questInteractable.IsInteractable)
                {
                    questInteractable.EnableSelectOutline();
                    _lastInteractable = questInteractable;
                }
            }
        }

        private bool TryGetInteractable(out QuestInteractable questInteractable)
        {
            questInteractable = null;
            Ray ray = new(_camera.transform.position, _camera.transform.forward);

            int count = Physics.RaycastNonAlloc(ray, _hits, _rayLength);

            for (int i = 0; i < count; i++)
            {
                if (_hits[i].transform.TryGetComponent(out questInteractable))
                {
                    return true;
                }
            }

            return false;
        }

        private void OnInteractButtonClicked()
        {  
            if (_lastInteractable)
            {
                _lastInteractable.DisableSelectOutline();
            }
            if (TryGetInteractable(out QuestInteractable questInteractable))
            {
                if (questInteractable.IsInteractable)
                {
                    questInteractable.Interact();
                    _lastInteractable = questInteractable;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Transform temp = Camera.main.transform;
           
            Gizmos.DrawWireSphere(temp.position, _rayLength);
        }
    }
}