using System;
using System.Collections;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;

namespace Trellcko.Gameplay.Trigger
{
   public abstract class BaseEvent : MonoBehaviour
   {
      [SerializeField] private float _delay;

      private Notifier _activator;

      public void Init(Notifier activator)
      {
         _activator = activator;
         if (_activator)
            _activator.Activated += OnNotifierInvoked;
      }

      
      private void OnDestroy()
      {
         if (_activator)
            _activator.Activated -= OnNotifierInvoked;
      }
      
      private void OnNotifierInvoked()
      {
         StartCoroutine(NotifeCorun());
      }

      private IEnumerator NotifeCorun()
      {
         OnBeforeNotifierInvoked();
         yield return new WaitForSeconds(_delay);
         OnNotifierInvokeHandle();
         _activator.Activated -= OnNotifierInvoked;
      }
      
      public void MakeVisible()
      {
         OnMakeVisible();
      }
      
      protected abstract void OnBeforeNotifierInvoked();
      
      protected abstract void OnMakeVisible();
      
      protected abstract void OnNotifierInvokeHandle();
      
   }
}