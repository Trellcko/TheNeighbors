using System.Collections.Generic;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
   public class DayResetting : MonoBehaviour, IDayResetting
   {
      [SerializeField] private Rigidbody _player;

      [SerializeField] private Transform _playerSpawnPosition;

      [SerializeField] private List<ResetObjectData> _resetObjectData;

      public void ResetItemsFor(int day)
      {
         _player.MovePosition(_playerSpawnPosition.position);

         foreach (ResetObject resetForObject in _resetObjectData[day].Items)
         {
            resetForObject.Reset();
         }
      }
   }
}