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
        
        public void Disable()
        {
            _highlightEffect.highlighted = false;
        }
        
        [Button]
        public void EnableSelectOutline(bool force = true)
        {
            if(force)
                _highlightEffect.highlighted = true;
            _highlightEffect.ProfileLoad(_selectProfile);
        }

        [Button]
        public void EnableInteractOutline(bool force = true)
        {
            if(force)
                _highlightEffect.highlighted = true;
            _highlightEffect.ProfileLoad(_interactableProfile);
        }
    }
}