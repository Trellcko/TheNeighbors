using System;
using System.Collections.Generic;
using Trellcko.Core.Input;
using Trellcko.Gameplay.Player;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.MiniGame
{
    public class ClosetMiniGame : MonoBehaviour, IMiniGame
    {
        [SerializeField] private List<ClosetMiniGameData> _closetMiniGameData;
        
        [SerializeField] private ClothesMiniGameInteractable _clothesInteractable;
        
        [SerializeField] private CinemachineCamera _camera;
        public MiniGameType MinigameType => MiniGameType.ClosetMiniGame;

        private PlayerFacade _playerFacade;
        public event Action<bool, IMiniGame> Finished;

        [Inject]
        private void Construct(PlayerFacade playerFacade)
        {
            _playerFacade = playerFacade;
        }

        public void StartGame()
        {
            _camera.enabled = true;
            _playerFacade.PlayerMovement.IsEnabled = false;
            _playerFacade.PlayerRotation.IsEnabled = false;
            _playerFacade.Interactable.IsEnabled = false;
        }

        public void FinishGame(bool success)
        {
            Finished?.Invoke(success, this);
        }

        public void ExitGame()
        {
            _camera.enabled = false;
            _playerFacade.PlayerMovement.IsEnabled = true;
            _playerFacade.PlayerRotation.IsEnabled = true;
            _playerFacade.Interactable.IsEnabled = true;
        }
    }
}