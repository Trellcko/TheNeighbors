using System;
using Trellcko.UI;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.QuestLogic
{
    public class QuestUIActor : MonoBehaviour
    {
        [SerializeField] private QuestUI _questUI;
        [SerializeField] private AudioSource _audioSource;
        private IQuestSystem _questSystem;

        [Inject]
        private void Construct(IQuestSystem questSystem)
        {
            _questSystem = questSystem;
        }

        private void Awake()
        {
            _questSystem.AllDaysCompleted += OnAllQuestsCompleted;
            _questSystem.DayStarted += OnDayStarted;
        }

        private void OnDestroy()
        {
            _questSystem.AllDaysCompleted -= OnAllQuestsCompleted;
            _questSystem.DayStarted -= OnDayStarted;
        }

        private void OnDayStarted()
        {
            Debug.Log("Started Day " + _questSystem.Day);
            _questSystem.CurrentDayList.BeforeQuestActivated += OnQuestCompleted;
            _questUI.ForceSetText(_questSystem.CurrentDayList.CurrentQuest.Description);
        }

        private void OnAllQuestsCompleted()
        {
            _questSystem.AllDaysCompleted -= OnAllQuestsCompleted;
            _questSystem.CurrentDayList.QuestActivated -= OnQuestActivated;
            _questSystem.CurrentDayList.BeforeQuestActivated -= OnQuestCompleted;
            _questUI.Disable();
        }

        private void Start()
        {
            _questUI.ForceSetText(_questSystem.CurrentDayList.CurrentQuest.Description);
        }

        private void OnQuestCompleted()
        {   
            Debug.Log("Completed Quest " + _questSystem.CurrentDayList.CurrentQuest.Description);
            _questSystem.CurrentDayList.QuestActivated -= OnQuestActivated;
            _questSystem.CurrentDayList.QuestActivated += OnQuestActivated;
        }

        private void OnQuestActivated()
        {
            Debug.Log("Started Quest " + _questSystem.CurrentDayList.CurrentQuest.Description);
            _audioSource.Play();
            _questUI.SetTextWithAnimation(_questSystem.CurrentDayList.CurrentQuest.Description);
        }
    }
}