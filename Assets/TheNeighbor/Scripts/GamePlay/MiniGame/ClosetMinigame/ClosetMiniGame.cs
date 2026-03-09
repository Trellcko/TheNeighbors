using System;
using System.Collections.Generic;
using UnityEngine;

namespace Trellcko.Gameplay.MiniGame
{
    public class ClosetMiniGame : MonoBehaviour, IMiniGame
    {
        [SerializeField] private List<ClosetMiniGameData> _closetMiniGameData;

        [SerializeField] private List<Sprite> _clothes;
        [SerializeField] private List<Sprite> _corpses;

        [SerializeField] private GameObject _draggablePrefab;
        [SerializeField] private Material _draggableMaterial;
        
        private Camera _camera;
        public MiniGameType MinigameType => MiniGameType.ClosetMiniGame;

        public event Action<bool, IMiniGame> Finished;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void StartGame()
        {
            _camera.enabled = true;
        }

        public void FinishGame(bool success)
        {
            throw new NotImplementedException();
        }

        public void ExitGame()
        {
            throw new NotImplementedException();
        }
    }
}