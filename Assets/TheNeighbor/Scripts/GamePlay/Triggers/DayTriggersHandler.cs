using System;
using System.Collections.Generic;
using System.Linq;
using Trellcko.Gameplay.Trigger;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.QuestLogic
{
    public class DayTriggersHandler : MonoBehaviour
    {
        [SerializeField] private List<DayTriggerList> _dayTriggersData;
        
        private IQuestSystem _questSystem;

        [Inject]
        private void Construct(IQuestSystem questSystem)
        {
            _questSystem = questSystem;
        }

        private void OnEnable()
        {
            _questSystem.CurrentDayList.QuestActivated += OnQuestActivated;
            _questSystem.DayStarted += OnDayStarted;
            _questSystem.DayCompleted += OnDayCompleted;
        }

        private void OnDisable()
        {
            _questSystem.CurrentDayList.QuestActivated -= OnQuestActivated;
            _questSystem.DayStarted -= OnDayStarted;
        }

        private void OnDayStarted()
        {
            _questSystem.CurrentDayList.QuestActivated += OnQuestActivated;
        }

        private void OnDayCompleted()
        {
            _questSystem.CurrentDayList.QuestActivated -= OnQuestActivated;
        }

        private void OnQuestActivated()
        {
            if (_dayTriggersData.Count > _questSystem.Day)
            {
                DayTriggerData data = _dayTriggersData[_questSystem.Day]._dayTriggersData.FirstOrDefault(x => x.QuestIndex == _questSystem.CurrentDayList.QuestIndex);
                data?.BaseTrigger.MakeVisible();
            }
        }
    }
    [Serializable]

    public class DayTriggerList
    {
        public List<DayTriggerData> _dayTriggersData;
    }
    
    [Serializable]
    public class DayTriggerData
    {
        public int QuestIndex;
        public BaseTrigger BaseTrigger;
    }
}