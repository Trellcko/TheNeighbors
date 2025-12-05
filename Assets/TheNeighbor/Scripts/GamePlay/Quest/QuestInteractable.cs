using System;
using HighlightPlus;
using NaughtyAttributes;
using Trellcko.Gameplay.Interactable;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public enum QuestItem
    {
        None, 
        Clothes,
        Mop,
        WaterThing
    }
    
    public class QuestInteractable : MonoBehaviour, IInteractable
    {
        [field: SerializeField] public InteractableOutline InteractableOutline { get; private set; }
        [field: SerializeField] public QuestItem NeededItem { get; private set; } = QuestItem.None;
        [field: SerializeField] public QuestItem ReceiveItem { get; private set; } = QuestItem.None;
        
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private bool _disableAfterGetting;
        public event Action Interacted;
        public bool IsInteractable { get; private set; }
        
        [Button]
        public void EnableInteraction()
        {
            IsInteractable = true;
            InteractableOutline.EnableInteractOutline();
        }

        public bool TryInteract(out QuestItem getItem, QuestItem neededItem)
        {
            getItem = ReceiveItem;
            if (!IsInteractable || NeededItem != neededItem)
                return false;

            Interacted?.Invoke();
            if (_audioSource)
                _audioSource?.Play();
            IsInteractable = false;
            InteractableOutline.Disable();
            if (_disableAfterGetting)
            {
                gameObject.SetActive(false);
            }

            return true;
        }

    }
}