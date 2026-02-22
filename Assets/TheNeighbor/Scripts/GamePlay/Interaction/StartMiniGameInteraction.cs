using System;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.Interactable
{
    [RequireComponent(typeof(IInteractable))]
    public class StartMiniGameInteraction : MonoBehaviour
    {
        [SerializeField] private MiniGameType _minigameType;
        private IInteractable _interactable;
        private MiniGamesController _minigameController;

        [Inject]
        private void Construct(MiniGamesController controller)
        {
            _minigameController = controller;
        }
        
        private void Awake()
        {
            _interactable = GetComponent<IInteractable>();
        }

        private void OnEnable()
        {
            _interactable.Interacted += OnInteracted;
        }

        private void OnDisable()
        {
            _interactable.Interacted -= OnInteracted;
        }

        private void OnInteracted()
        {
            _minigameController.StartMiniGame(_minigameType);
        }
    }
}