using System.Collections;
using UnityEngine;

namespace Trellcko.Gameplay.Trigger
{
   public abstract class BaseTrigger : MonoBehaviour
   {
      [SerializeField] private TriggerActivation _activation;
      [SerializeField] private float _delay;

      private bool _isVisible = false;
      
      private void OnBecameVisible()
      {
         if (_isVisible)
         {
            if (_activation == TriggerActivation.WhenSee)
            {
               StartCoroutine(ActivateCorun());
            }
         }
      }

      private IEnumerator ActivateCorun()
      {
         yield return new WaitForSeconds(_delay);
         OnActivate();
      }



      public void MakeVisible()
      {
         OnMakeVisible();
         _isVisible = true;
      }
      
      protected abstract void OnMakeVisible();
      
      protected abstract void OnActivate();
      
   }

   public enum TriggerActivation
   {
      WhenSee
   }
}