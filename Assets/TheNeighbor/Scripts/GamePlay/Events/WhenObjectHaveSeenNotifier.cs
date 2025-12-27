using Trellcko.Gameplay.Common;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public class WhenObjectHaveSeenNotifier : Notifier
    {       
        [SerializeField] private BecomeVisibleInvoker _becomeVisibleInvoker;

        private void OnDisable()
        {
            _becomeVisibleInvoker.BecameVisible -= OnBecameVisible;
        }

        private void OnBecameVisible()
        {
            InvokeNotified();
            _becomeVisibleInvoker.BecameVisible -= OnBecameVisible;
        }

        public override void StartWatching()
        {            
            _becomeVisibleInvoker.BecameVisible += OnBecameVisible;
        }
    }
}