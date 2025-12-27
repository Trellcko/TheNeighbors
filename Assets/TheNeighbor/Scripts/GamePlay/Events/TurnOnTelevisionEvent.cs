using UnityEngine;

namespace Trellcko.Gameplay.Events
{
    public class TurnOnTelevisionEvent : BaseEvent
    {
        [SerializeField] private TVController _TVController;
        protected override void OnBeforeNotifierInvoked()
        {
            
        }

        protected override void OnMakeVisible()
        {
            _TVController.TurnOn();
        }

        protected override void OnNotifierInvokeHandle()
        {
            
        }
    }
}