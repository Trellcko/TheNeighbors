using System;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public abstract class Notifier : MonoBehaviour
    {
        public event Action Activated;
        protected void InvokeNotified()
        {
            Activated?.Invoke();
        }

        public abstract void StartWatching();
    }
}