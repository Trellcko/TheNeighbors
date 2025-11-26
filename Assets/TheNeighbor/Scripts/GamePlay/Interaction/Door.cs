using System;
using DG.Tweening;
using NaughtyAttributes;
using Trellcko.Gameplay.Interactable;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;
using Zenject;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private float _openTime;
    [field: SerializeField] public InteractableOutline InteractableOutline { get; private set; }
    public bool IsInteractable { get; private set; }
    
    private PlayerFacade _playerFacade;

    public event Action Interacted;

    private Vector3 _defaultAngel;

    private Tween _tween;

    [Inject]
    private void Construct(PlayerFacade playerFacade)
    {
        _playerFacade = playerFacade;
    }

    private void Awake()
    {
        _defaultAngel = transform.eulerAngles;
    }

    public bool TryInteract(out QuestItem getItem, QuestItem neededItem)
    {
        getItem = neededItem;
        if (IsInteractable && _playerFacade)
        {
            IsInteractable = false;
            float angel = GetOpenAngel();
            Vector3 targetAngel = _defaultAngel;
            targetAngel.y = angel;
            _tween = transform.DORotate(targetAngel, _openTime);
            
            return true;
        }

        return false;
    }

    public void ReturnToInit()
    {
        _tween = transform.DORotate(_defaultAngel, _openTime).OnComplete(() => IsInteractable = true);
    }

    private float GetOpenAngel()
    {
        Vector3 toPlayer = (_playerFacade.transform.position - transform.position).normalized;
        float dot = Vector2.SignedAngle(transform.forward, toPlayer);
        if (dot > 0)
        {
            return -90;
        }
        return 90;
    }
}
