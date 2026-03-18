using System;
using System.Collections.Generic;
using NUnit.Framework;
using Trellcko.Gameplay.Player;
using Trellcko.Gameplay.QuestLogic;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.MiniGame
{
    public class CookiesMiniGame : MonoBehaviour, IMiniGame
    {
        [SerializeField] private Vector3 _handStartPosition;
        [SerializeField] private HandController _handController;
        [SerializeField] private CinemachineCamera _cinemachineCamera;
        [SerializeField] private List<CookiesMiniGameData> _cookiesMiniGameData;
        private PlayerFacade _playerFacade;

        public bool IsStarted { get; private set; }
        public MiniGameType MinigameType => MiniGameType.CookiesMiniGame;
        public event Action<bool, IMiniGame> Finished;

        [Inject]
        private void Construct(PlayerFacade playerFacade)
        {
            _playerFacade = playerFacade;
        }
        
        public void StartGame()
        {
            IsStarted = true;
            _handController.transform.localPosition = _handStartPosition;
            _playerFacade.PlayerMovement.IsEnabled = false;
            _playerFacade.PlayerRotation.IsEnabled = false;
            _playerFacade.Interactable.IsEnabled = false;
            _handController.enabled = true;
            _cinemachineCamera.enabled = true;
        }

        public void FinishGame(bool success)
        {
            IsStarted = false;
            Finished?.Invoke(success,this);
        }

        public void ExitGame()
        {
            _handController.enabled = false;
            _playerFacade.PlayerMovement.IsEnabled = true;
            _playerFacade.PlayerRotation.IsEnabled = true;
            _playerFacade.Interactable.IsEnabled = true;
        }
    }

    [Serializable]
    public class CookiesMiniGameData
    {
        public float cookiesChance;
        public int needCookies;
    }
}