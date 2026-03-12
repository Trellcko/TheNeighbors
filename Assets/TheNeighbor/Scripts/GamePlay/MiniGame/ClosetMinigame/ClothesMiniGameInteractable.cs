using System;
using Trellcko.Gameplay.Interactable;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.MiniGame
{
    public class ClothesMiniGameInteractable : MonoBehaviour, IInteractable
    {
        [field: SerializeField] public InteractableOutline InteractableOutline { get; private set; }
        [SerializeField] private ClothesDraggable _clothesPrefab;

        public bool IsInteractable { get; private set; } = true;

        private ClosetMiniGameData _closetMiniGameData;
        private DiContainer _container;

        public event Action Interacted;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }
        
        public bool TryInteract(out QuestItem getItem, QuestItem neededItem)
        {
            getItem = neededItem;
            if (!IsInteractable) return false;
            GameObject clothesInstance = _container.InstantiatePrefab(_clothesPrefab);
            clothesInstance.transform.position = transform.position;
            IsInteractable = false;
            return true;
        }

        public void SetMiniGameData(ClosetMiniGameData closetMiniGameData)
        {
            _closetMiniGameData = closetMiniGameData;
        }
        
    }
}