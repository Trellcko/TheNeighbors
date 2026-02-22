using System;
using System.Collections.Generic;
using System.Linq;
using Trellcko.Gameplay.MiniGame;
using UnityEngine;

public class MiniGamesController : MonoBehaviour
{
   [SerializeField] private List<GameObject> _minigamesGO;
   
   private List<IMiniGame> _minigames = new();

   private void Awake()
   {
      foreach (GameObject miniGameGo in _minigamesGO)
      {
         if (miniGameGo.TryGetComponent(out IMiniGame miniGame))
         {
            _minigames.Add(miniGame);
         }
         else
         {
            Debug.LogError($"{miniGameGo.name} has no IMiniGame");
         }
      }
   }

   public void StartMiniGame(MiniGameType miniGameType)
   {
      foreach (IMiniGame minigame in _minigames.Where(minigame => minigame.MinigameType == miniGameType))
      {
         minigame.StartGame();
         return;
      }

      Debug.LogError($"No MiniGame {miniGameType} found");
   }
}

public enum MiniGameType
{
   WindowMiniGame
}