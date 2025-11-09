using System;
using HighlightPlus;
using Mono.Cecil;
using NaughtyAttributes;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public class QuestInteractable : MonoBehaviour
    {
        [SerializeField] private HighlightEffect _highlightEffect;
        [SerializeField] private AudioSource _audioSource;
        
        private HighlightProfile _selectProfile;
        private HighlightProfile _interactableProfile;
        
        public event Action Interacted;
        public bool IsInteractable { get; private set; }

        private void Awake()
        {
            _interactableProfile = Resources.Load<HighlightProfile>("Outline/InteractableOutline");
            _selectProfile = Resources.Load<HighlightProfile>("Outline/SelectedOutline");
        }
        
        [Button]
        public void EnableInteraction()
        {
            IsInteractable = true;
            _highlightEffect.ProfileLoad(_interactableProfile);
            _highlightEffect.highlighted = true;
        }

        [Button]
        public void Interact()
        {
            Interacted?.Invoke();
            _audioSource?.Play();
            IsInteractable = false;
            _highlightEffect.highlighted = false;
        }
        
        [Button]
        public void EnableSelectOutline()
        {
            _highlightEffect.ProfileLoad(_selectProfile);
        }

        [Button]
        public void DisableSelectOutline()
        {
            _highlightEffect.ProfileLoad(_interactableProfile);
        }
    }
}