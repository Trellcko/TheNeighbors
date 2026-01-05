using System;
using System.Collections.Generic;
using Trellcko.Core.Audio;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.QuestLogic
{
    public class QuestSystem : MonoBehaviour, IQuestSystem
    {
        [SerializeField] private List<QuestsDayList> _questDays;
        [SerializeField] private int _startDay;
        public QuestsDayList CurrentDayList => _questDays[Day];
        public int Day { get; private set; }

        private ISoundController _soundController;
        public event Action DayCompleted;
        public event Action DayStarted;
        public event Action AllDaysCompleted;

        [Inject]
        private void Construct(ISoundController soundController)
        {
            _soundController = soundController;
        }
        
        private void Awake()
        {
#if UNITY_EDITOR
            Day = _startDay;
#endif
            _questDays[0].AllQuestsCompleted += OnAllQuestsInDayCompleted;
        }

        private void Start()
        {

            StartCurrentDay();
        }

        public void StartNextDay()
        {
            Day++;
            _questDays[Day].AllQuestsCompleted += OnAllQuestsInDayCompleted;
            StartCurrentDay();
        }

        private void StartCurrentDay()
        {
            _soundController.PlayOst(_questDays[Day].Ost);
            _questDays[Day].Init();
            DayStarted?.Invoke();
        }

        private void OnAllQuestsInDayCompleted()
        {
            _questDays[Day].AllQuestsCompleted -= OnAllQuestsInDayCompleted;
            _soundController.StopPlayingAmbience();
            DayCompleted?.Invoke();
            if (Day == _questDays.Count - 1)
            {
                AllDaysCompleted?.Invoke();
            }
        }
    }
}