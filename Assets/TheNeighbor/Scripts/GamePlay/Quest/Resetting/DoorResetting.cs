using Trellcko.Gameplay.Interactable;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
   public class DoorResetting : ResetObject
   {
      [SerializeField] private Door _door;
      

      public override void Reset()
      {
         _door.ReturnToInitImmediately();
      }
   }
}