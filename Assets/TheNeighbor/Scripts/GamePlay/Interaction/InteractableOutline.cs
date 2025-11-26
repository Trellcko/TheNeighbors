using System;
using HighlightPlus;
using NaughtyAttributes;
using UnityEngine;

namespace Trellcko.Gameplay.Interactable
{
    public class InteractableOutline : MonoBehaviour
    {
        [SerializeField] private HighlightEffect _highlightEffect;
        
        private HighlightProfile _interactableProfile;
        private HighlightProfile _selectProfile;

        private void OnValidate()
        {
            if(!_highlightEffect)
                _highlightEffect = gameObject.AddComponent<HighlightEffect>();
        }

        private void Awake()
        {
            _interactableProfile = Resources.Load<HighlightProfile>("Outline/InteractableOutline");
            _selectProfile = Resources.Load<HighlightProfile>("Outline/SelectedOutline");
        }
        
        public void SetIsActive(bool isActive)
        {
            _highlightEffect.highlighted = isActive;
        }
        
        [Button]
        public void EnableSelectOutline()
        {
            _highlightEffect.ProfileLoad(_selectProfile);
        }

        [Button]
        public void EnableInteractOutline()
        {
            _highlightEffect.ProfileLoad(_interactableProfile);
        }
    }
}