using System;
using DG.Tweening;
using Trellcko.Gameplay.Player;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.Interactable
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private Collider _goCollider;
        [SerializeField] private AudioSource _interactAudio;
        [field: SerializeField] public InteractableOutline InteractableOutline { get; private set; }
        public bool IsInteractable { get; private set; } = true;

        public event Action Interacted;

        private PlayerFacade _playerFacade;
        private Vector3 _defaultAngel;

        private const float OpenTime = 3f;

        [Inject]
        private void Construct(PlayerFacade playerFacade)
        {
            _playerFacade = playerFacade;
        }

        private void Awake()
        {
            _defaultAngel = transform.localEulerAngles;
        }

        public bool TryInteract(out QuestItem getItem, QuestItem neededItem)
        {
            getItem = neededItem;
            if (IsInteractable && _playerFacade)
            {
                InteractableOutline.Disable();
                IsInteractable = false;
                float angel = GetOpenAngel();
                Vector3 targetAngel = _defaultAngel;
                targetAngel.y = angel;
                _interactAudio.Play();
                Interacted?.Invoke();
                transform.DOLocalRotate(targetAngel, OpenTime)
                    .OnComplete(() => { _goCollider.enabled = false; });

                return true;
            }

            return false;
        }

        public void ReturnToInitImmediately()
        {
            transform.localRotation = Quaternion.Euler(_defaultAngel);
            IsInteractable = true;
            _goCollider.enabled = true;
        }

        public void ReturnToInit()
        {
            if (!IsInteractable && _goCollider.enabled)
                return;

            _interactAudio.Play();
            _goCollider.enabled = true;
            transform.DOLocalRotate(_defaultAngel, OpenTime).OnComplete(() => IsInteractable = true);
        }

        private float GetOpenAngel()
        {
            Vector3 toPlayer = _playerFacade.transform.position - transform.position;

            Vector3 doorNormal = transform.up;

            float side = Vector3.SignedAngle(
                transform.forward,
                toPlayer,
                doorNormal
            );

            return side > 0f ? 115f : -115f;
        }
    }
}
