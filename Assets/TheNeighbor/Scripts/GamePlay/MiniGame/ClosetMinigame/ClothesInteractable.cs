using System;
using Trellcko.Gameplay.Interactable;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Trellcko.Gameplay.MiniGame
{
    public class ClothesInteractable : MonoBehaviour, IInteractable
    {
        [field: SerializeField] public InteractableOutline InteractableOutline { get; private set; }
        [SerializeField] private ClothesDraggable _clothesPrefab;
        [SerializeField] private ClothesSpriteData _clothesSpriteData;
        public bool IsInteractable { get; private set; }

        private int _currentCorpses;
        private int _currentClothes;
        
        private ClosetMiniGameData _closetMiniGameData;
        private DiContainer _container;

        public event Action ClothesGenerated;
        public event Action Reseted;
        public event Action ClothesRunOut;
        
        public event Action Interacted;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        public void SetMiniGameData(ClosetMiniGameData closetMiniGameData)
        {
            _closetMiniGameData = closetMiniGameData;
            _currentClothes = closetMiniGameData.ClothesCount;
            _currentCorpses = closetMiniGameData.CorpseCount;
            IsInteractable = true;
            Reseted?.Invoke();
        }

        public bool TryInteract(out QuestItem getItem, QuestItem neededItem)
        {
            getItem = neededItem;
            if (!IsInteractable) return false;
            ClothesDraggable clothesInstance = _container.InstantiatePrefab(_clothesPrefab).GetComponent<ClothesDraggable>();
            clothesInstance.transform.position = transform.position;
            clothesInstance.Putted += OnPutted;
            clothesInstance.UpdateSprite(TakeRandomSprite());
            ClothesGenerated?.Invoke();
            IsInteractable = false;
            return true;
        }

        private void OnPutted(ClothesDraggable obj)
        {
            obj.Putted -= OnPutted;
            if (_currentClothes <= 0 && _currentCorpses <= 0)
            {
                ClothesRunOut?.Invoke();
                return;
            }
            Reseted?.Invoke();
            IsInteractable = true;

        }

        private Sprite TakeRandomSprite()
        {
            bool takeFirst;

            if (_currentClothes <= 0)
                takeFirst = false;
            else if (_currentCorpses <= 0)
                takeFirst = true;
            else
                takeFirst = UnityEngine.Random.Range(0, 1f) > 0.5f;

            if (takeFirst)
            {
                _currentClothes--;
                return _clothesSpriteData.ClothesSprites[Random.Range(0, _clothesSpriteData.ClothesSprites.Count)];
            }

            _currentCorpses--;
            return _clothesSpriteData.CorpsesSprites[Random.Range(0, _clothesSpriteData.CorpsesSprites.Count)];
        }
    }
}