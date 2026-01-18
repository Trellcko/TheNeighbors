using System;
using Trellcko.Core.Input;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GoBackToMainMenuHelper : MonoBehaviour
{
   private IQuestSystem _questSystem;

   [Inject]
   private void Construct(IQuestSystem questSystem, IInputHandler inputHandler)
   {
       _questSystem = questSystem;
   }

   private void Update()
   {
       if (_questSystem.AreAllQuestsCompleted)
       {
           if (Keyboard.current.enterKey.wasPressedThisFrame)
           {
               //TODO GO TO THE MAIN MENU
           }
       }
   }
}
