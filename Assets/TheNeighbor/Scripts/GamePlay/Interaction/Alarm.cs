using System;
using Trellcko.Gameplay.Interactable;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;

public class Alarm : MonoBehaviour, IInteractable
{
    [field: SerializeField] public InteractableOutline InteractableOutline { get; private set; }
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _alarm;
    [SerializeField] private AudioClip _turnOffAlarm;

    public event Action Interacted;
    public bool IsInteractable { get; private set; }

    public void Activate()
    {
        IsInteractable = true;
        _audioSource.clip = _alarm;
        _audioSource.loop = true;
        _audioSource.Play();
    }
    
    public bool TryInteract(out QuestItem getItem, QuestItem neededItem)
    {
        getItem = neededItem;
        if (!IsInteractable) return false;
        _audioSource.clip = _turnOffAlarm;
        _audioSource.loop = false;
        _audioSource.Play();
        Interacted?.Invoke();
        IsInteractable = false;
        InteractableOutline.Disable();
        return true;
    }
}
