using System;
using Trellcko.Gameplay.Interactable;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;

namespace Trellcko.Gameplay
{
    public class TVController : MonoBehaviour, IInteractable
    {
        [field: SerializeField] public InteractableOutline InteractableOutline { get; private set; }
        
        [SerializeField] private Light _light;
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private AudioSource _audio;

        public bool IsWorked { get; private set; } = true;

        public event Action Interacted;

        public bool IsInteractable => true;

        public bool TryInteract(out QuestItem getItem, QuestItem neededItem)
        {
            getItem = neededItem;
            if (!IsInteractable)
                return false;
            if (IsWorked)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
            
            return true;
        }

        public void TurnOn()
        {
            IsWorked = true;
            _light.enabled = true;
            _particle.Play();
            _audio.Play();
        }

        public void TurnOff()
        {
            IsWorked = false;
            _light.enabled = false;
            _particle.Stop();
            _audio.Stop();
        }
    }
}