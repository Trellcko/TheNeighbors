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
        private PlayerFacade _player;
        private IQuestSystem _questSystem;

        private PlayerMovement PlayerMovement => _player.PlayerMovement;
        private PlayerRotation PlayerRotation => _player.PlayerRotation;
        
        [Inject]
        private void Construct(IQuestSystem questSystem, PlayerFacade player, FinishDayUI finishDayUI)
        {
            _player = player;
            _questSystem = questSystem;
            _finishDayUI = finishDayUI;
        }

        private void Awake()
        {
            _questSystem.DayCompleted += OnDayCompleted;
        }

        private void OnDestroy()
        {
            _questSystem.DayCompleted -= OnDayCompleted;
        }

        private void OnDayCompleted()
        {
            PlayerMovement.IsEnabled = PlayerRotation.IsEnabled = false;
            if (_questSystem.Day == 0)
            {
                _finishDayUI.Hide(() => PlayerMovement.IsEnabled = PlayerRotation.IsEnabled = true);
                return;
            }
            
            _finishDayUI.ShowAndHide(_questSystem.Day + 1, () =>
            {
                _questSystem.StartNextDay();
                PlayerMovement.IsEnabled = PlayerRotation.IsEnabled = true;
            });
        }
    }
}