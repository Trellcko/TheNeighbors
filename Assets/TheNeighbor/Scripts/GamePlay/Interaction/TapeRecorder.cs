using System;
using Trellcko.Core.Audio;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.Interactable
{
    public class TapeRecorder : MonoBehaviour, IInteractable
    {
        [field: SerializeField] public InteractableOutline InteractableOutline { get; private set; }
        public bool IsInteractable => true;
        public event Action Interacted;

        private ISoundController _soundController;
        
        [Inject]
        private void Construct(ISoundController soundController)
        {
            _soundController = soundController;
        }
        
        public bool TryInteract(out QuestItem getItem, QuestItem neededItem)
        {
            getItem = neededItem;
            if (_soundController.IsAmbiencPlaying)
            {
                _soundController.StopPlayingAmbience();
            }
            else
            {
                _soundController.PlayAmbience(_soundController.CurrentAmbience);
            }

            return true;
        }
    }
}