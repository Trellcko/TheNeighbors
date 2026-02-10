using System;
using System.Collections;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;

namespace Trellcko.Gameplay.Interactable
{
    public class Phone : MonoBehaviour, IInteractable
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _ringClip;
        [SerializeField] private AudioClip _hangUpPhoneClip;
        [SerializeField] private AudioClip _monsterSound;
        [field: SerializeField] public InteractableOutline InteractableOutline { get; private set; }
        public bool IsInteractable { get; private set; }
        public event Action Interacted;

        private void Awake()
        {
            Activate();
        }

        public void Activate()
        {
            IsInteractable = true;
            _audioSource.clip = _ringClip;
            _audioSource.Play();
            _audioSource.loop = true;
        }
        
        public bool TryInteract(out QuestItem getItem, QuestItem neededItem)
        {
            getItem = neededItem;
            IsInteractable = false;
            _audioSource.clip = _hangUpPhoneClip;
            _audioSource.Play();
            _audioSource.loop = false;
            StartCoroutine(PlayMonsterSound());
            return true;
        }

        private IEnumerator PlayMonsterSound()
        {
            yield return new WaitForSeconds(1f);
            _audioSource.clip = _monsterSound;
            _audioSource.Play();
        }
    }
}