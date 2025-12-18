using System;
using System.Collections;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;

namespace Trellcko.Gameplay.Trigger
{
   public abstract class BaseTrigger : MonoBehaviour
   {
      [SerializeField] private TriggerActivator _activator;
      [SerializeField] private float _delay;
      private void OnEnable()
      {
         _activator.Activated += OnTriggerActivatorInvoked;
      }

      private void OnDisable()
      {
         _activator.Activated -= OnTriggerActivatorInvoked;
      }

      private void OnTriggerActivatorInvoked()
      {
         StartCoroutine(ActivateCorun());
      }

      private IEnumerator ActivateCorun()
      {
         yield return new WaitForSeconds(_delay);
         OnActivate();
      }
      
      public void MakeVisible()
      {
         OnMakeVisible();
      }
      
      protected abstract void OnMakeVisible();
      
      protected abstract void OnActivate();
      
   }
}