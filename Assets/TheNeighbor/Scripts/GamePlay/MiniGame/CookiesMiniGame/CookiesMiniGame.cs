using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Trellcko.Gameplay.Player;
using Trellcko.Gameplay.QuestLogic;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Trellcko.Gameplay.MiniGame
{
    public class CookiesMiniGame : MonoBehaviour, IMiniGame
    {
        [SerializeField] private Vector3 _handStartPosition;
        [SerializeField] private HandController _handController;
        [SerializeField] private CinemachineCamera _cinemachineCamera;
        [SerializeField] private List<CookiesMiniGameData> _cookiesMiniGameData;

        [SerializeField] private float _spawnTime = 1f;
        [SerializeField] private float _minDistanceBetweenCookies = 1f;
        [SerializeField] private List<Cookie> _goodCookies;
        [SerializeField] private List<Cookie> _badCookies;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        private Vector3 _previousSpawnPoint;
        private float _totalDistance;
        private float _minStep;
        private float _currentT;

        private PlayerFacade _playerFacade;
        private Coroutine _spawningCoroutine;
        
        
        public bool IsPlaying { get; private set; }
        public MiniGameType MinigameType => MiniGameType.CookiesMiniGame;
        public event Action<bool, IMiniGame> Finished;

        [Inject]
        private void Construct(PlayerFacade playerFacade)
        {
            _playerFacade = playerFacade;
        }

        private void Awake()
        {
            _totalDistance = Vector3.Distance(_startPoint.position, _endPoint.position);
            _minStep = _minDistanceBetweenCookies / _totalDistance;
        }

        public void StartGame()
        {
            IsPlaying = true;
            _handController.transform.localPosition = _handStartPosition;
            _playerFacade.PlayerMovement.IsEnabled = false;
            _playerFacade.PlayerRotation.IsEnabled = false;
            _playerFacade.Interactable.IsEnabled = false;
            _handController.enabled = true;
            _cinemachineCamera.enabled = true;
            _spawningCoroutine = StartCoroutine(SpawningCorun());
        }

        private IEnumerator SpawningCorun()
        {
            WaitForSeconds wait = new WaitForSeconds(_spawnTime);
            
            while (true)
            {
                yield return wait;
                Vector3 position = GetSpawnPosition();
                SpawnCookie(position);
            }
        }

        private Cookie SpawnCookie(Vector3 position)
        {
            float chance = Random.Range(0f, 1f);
            List<Cookie> cookies = chance > _cookiesMiniGameData[0].cookiesChance ? _goodCookies : _badCookies;
            
            return Instantiate(cookies[Random.Range(0, cookies.Count)], position, Quaternion.identity);
        }

        private Vector3 GetSpawnPosition()
        {
            float randomStep = Random.Range(_minStep, 1f);   
            _currentT += randomStep;
            _currentT = Mathf.PingPong(_currentT, 1);
            return Vector3.Lerp(_startPoint.position, _endPoint.position, _currentT);
        }

        public void FinishGame(bool success)
        {
            IsPlaying = false;
            StopCoroutine(_spawningCoroutine);
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