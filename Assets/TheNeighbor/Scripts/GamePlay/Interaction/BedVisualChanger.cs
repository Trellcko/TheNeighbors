using System;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;

namespace Trellcko.Gameplay.Interactable
{
    public class BedVisualChanger : MonoBehaviour
    {
        [SerializeField] private Material _badBed;
        [SerializeField] private Material _goodBed;

        [SerializeField] private MeshRenderer _meshRenderer;

        [SerializeField] private QuestInteractable _interactable;

        private void OnEnable()
        {
            _interactable.Interacted += OnInteracted;
        }

        private void OnDisable()
        {
            _interactable.Interacted -= OnInteracted;
        }

        private void OnInteracted()
        {
            _meshRenderer.sharedMaterials[2] = _goodBed;
        }


    }
}