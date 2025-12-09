using System;
using UnityEngine;

namespace Trellcko.Gameplay.Cinematic
{
    public abstract class BaseCinematic : MonoBehaviour
    {
        public event Action Completed;
        public abstract void Play();

        public virtual void DisableObjects()
        {
            
        }
        protected void InvokeCompleted()
        {
            Completed?.Invoke();
        }
    }
}