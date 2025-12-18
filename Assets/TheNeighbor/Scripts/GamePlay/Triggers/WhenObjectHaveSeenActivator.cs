using Trellcko.Gameplay.Common;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public class WhenObjectHaveSeenActivator : TriggerActivator
    {       
        [SerializeField] private BecomeVisibleInvoker _becomeVisibleInvoker;

        private void OnEnable()
        {
            _becomeVisibleInvoker.BecameVisible += OnBecameVisible;
        }

        private void OnDisable()
        {
            _becomeVisibleInvoker.BecameVisible -= OnBecameVisible;
        }

        private void OnBecameVisible()
        {
            InvokeActivated();
        }
    }
}