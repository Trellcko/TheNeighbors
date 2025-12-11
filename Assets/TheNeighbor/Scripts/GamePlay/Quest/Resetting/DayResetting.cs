using System.Collections.Generic;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
   public class DayResetting : MonoBehaviour, IDayResetting
   {
      [SerializeField] private Transform _player;

      [SerializeField] private Transform _playerSpawnPosition;

      [SerializeField] private List<ResetObjectData> _resetObjectData;

      public void ResetItemsFor(int day)
      {
         _player.position = _playerSpawnPosition.position;

         foreach (ResetObject resetForObject in _resetObjectData[day].Items)
         {
            resetForObject.Reset();
         }
      }
   }
}