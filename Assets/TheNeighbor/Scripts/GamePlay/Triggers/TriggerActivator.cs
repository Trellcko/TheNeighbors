using System;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public abstract class TriggerActivator : MonoBehaviour
    {
        public event Action Activated;

        protected void InvokeActivated()
        {
            Activated?.Invoke();
        }
    }
}