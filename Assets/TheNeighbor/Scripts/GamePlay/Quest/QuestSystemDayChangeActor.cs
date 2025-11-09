using Trellcko.Gameplay.Player;
using Trellcko.UI;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.QuestLogic
{
    public class QuestSystemDayChangeActor : MonoBehaviour
    {
        [SerializeField] private FinishDayUI _finishDayUI;
        [SerializeField] private PlayerRotation _playerRotation;
        [SerializeField] private PlayerMovement _playerMovement;
        
        private IQuestSystem _questSystem;

        [Inject]
        private void Construct(IQuestSystem questSystem)
        {
            _questSystem = questSystem;
        }

        private void Awake()
        {
            _questSystem.DayStarted += OnDayStarted;
        }

        private void OnDestroy()
        {
            _questSystem.DayStarted -= OnDayStarted;
        }

        private void OnDayStarted()
        {
            _playerMovement.IsEnabled = _playerRotation.IsEnabled = false;
            if (_questSystem.Day == 0)
            {
                _finishDayUI.Hide(1, () => _playerMovement.IsEnabled = _playerRotation.IsEnabled = true);
                return;
            }
            
            _finishDayUI.ShowAndHide(_questSystem.Day + 1, () => _playerMovement.IsEnabled = _playerRotation.IsEnabled = true);
        }
    }
}