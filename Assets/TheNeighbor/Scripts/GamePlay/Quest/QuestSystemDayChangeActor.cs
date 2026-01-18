using System;
using System.Collections.Generic;
using Trellcko.Gameplay.Cinematic;
using Trellcko.Gameplay.Player;
using Trellcko.UI;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.QuestLogic
{
    public class QuestSystemDayChangeActor : MonoBehaviour
    {
        [SerializeField] private List<BaseCinematic> _cinematic;

        private FinishDayUI _finishDayUI;
        private GameUI _gameUI;
        private PlayerFacade _player;
        private IQuestSystem _questSystem;
        private IDayResetting _dayResetting;

        private PlayerMovement PlayerMovement => _player.PlayerMovement;
        private PlayerRotation PlayerRotation => _player.PlayerRotation;

        [Inject]
        private void Construct(IQuestSystem questSystem, IDayResetting dayResetting, PlayerFacade player, FinishDayUI finishDayUI, GameUI gameUI)
        {
            _dayResetting = dayResetting;
            _player = player;
            _questSystem = questSystem;
            _finishDayUI = finishDayUI;
            _gameUI = gameUI;
        }

        private void Start()
        {
            _questSystem.DayCompleted += OnDayCompleted;
            _dayResetting.ResetItemsFor(_questSystem.Day);
        }

        private void OnDestroy()
        {
            _questSystem.DayCompleted -= OnDayCompleted;
        }

        private void OnDayCompleted()
        {
            PlayerMovement.IsEnabled = PlayerRotation.IsEnabled = false;

            if (_cinematic[_questSystem.Day])
            {
                ShowCinematic();
            }
            else if(!_questSystem.AreAllQuestsCompleted)
            {
                AnimationStartNextDay();
            }
            else
            {
                FinishGameAnimation();
            }
        }

        private void FinishGameAnimation()
        {
            _finishDayUI.ShowFinishGameUI();
        }

        private void OnCinematicCompleted()
        {
            _cinematic[_questSystem.Day].Completed -= OnCinematicCompleted;
            _gameUI.gameObject.SetActive(true);
            AnimationStartNextDay(_cinematic[_questSystem.Day].DisableObjects);
        }

        private void ShowCinematic()
        {
            _finishDayUI.ShowUI(-1, () =>
            {
                _gameUI.gameObject.SetActive(false);
                _cinematic[_questSystem.Day].Play();
                _cinematic[_questSystem.Day].Completed += OnCinematicCompleted;
                _finishDayUI.HideUI();
            });
        }

        private void AnimationStartNextDay(Action callback = null)
        {
            _finishDayUI.ShowUI(_questSystem.Day + 2, () =>
            {
                _dayResetting.ResetItemsFor(_questSystem.Day + 1);
                _questSystem.StartNextDay();
                _finishDayUI.HideUI(() =>
                {
                    PlayerMovement.IsEnabled = PlayerRotation.IsEnabled = true;
                });
                callback?.Invoke();
            });
        }
    }
}