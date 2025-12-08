using System;
using System.Collections.Generic;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public class QuestSystem : MonoBehaviour, IQuestSystem
    {
        [SerializeField] private List<QuestsDayList> _questDays;

        public QuestsDayList CurrentDayList => _questDays[Day]; 
        public int Day { get; private set; }

        public event Action DayCompleted;
        public event Action DayStarted;
        public event Action AllDaysCompleted;
        
        private void Awake()
        {
            _questDays[0].Init();
            _questDays[0].AllQuestsCompleted += OnAllQuestsInDayCompleted;
        }

        private void Start()
        {
            DayStarted?.Invoke();
        }

        public void StartNextDay()
        {
            Day++;            
            _questDays[Day].Init();
            _questDays[Day].AllQuestsCompleted += OnAllQuestsInDayCompleted;
            DayStarted?.Invoke();
        }
        
        private void OnAllQuestsInDayCompleted()
        {
            _questDays[Day].AllQuestsCompleted -= OnAllQuestsInDayCompleted;
            DayCompleted?.Invoke();
            if (Day == _questDays.Count - 1)
            {
                AllDaysCompleted?.Invoke();
            }
        }
    }
}