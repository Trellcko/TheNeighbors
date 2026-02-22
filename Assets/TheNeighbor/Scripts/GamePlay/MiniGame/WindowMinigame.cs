using System.Collections.Generic;
using UnityEngine;

namespace Trellcko.Gameplay.MiniGame
{
    public class WindowMinigame : MonoBehaviour, IMiniGame
    {
        [SerializeField] private List<int> _powers;

        public MiniGameType MinigameType => MiniGameType.WindowMiniGame;

        public void StartGame()
        {
            throw new System.NotImplementedException();
        }

        public void FinishGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
