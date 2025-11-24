using System;
using HighlightPlus;
using NaughtyAttributes;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public enum QuestItem
    {
        None, 
        Clothes
    }
    
    public class QuestInteractable : MonoBehaviour
    {
        
        [field: SerializeField] public QuestItem NeededItem { get; private set; } = QuestItem.None;
        [field: SerializeField] public QuestItem ReceiveItem { get; private set; } = QuestItem.None;
        
        [SerializeField] private HighlightEffect _highlightEffect;
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private bool _disableAfterGetting;
        
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

        public bool TryInteract(out QuestItem getItem, QuestItem neededItem)
        {
            getItem = ReceiveItem;
            if (!IsInteractable || NeededItem != neededItem)
                return false;
            
            Interacted?.Invoke();
            _audioSource?.Play();
            IsInteractable = false;
            _highlightEffect.highlighted = false;
            if (_disableAfterGetting)
            {
                gameObject.SetActive(false);
            }
            return true;
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