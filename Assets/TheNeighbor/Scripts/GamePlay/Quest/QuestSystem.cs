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

        public QuestsDayList CurrentDayList => _questDays[Day];
        public int Day { get; private set; }

        private IMusicController _musicController;
        public event Action DayCompleted;
        public event Action DayStarted;
        public event Action AllDaysCompleted;

        [Inject]
        private void Construct(IMusicController musicController)
        {
            _musicController = musicController;
        }
        
        private void Awake()
        {
            _questDays[0].AllQuestsCompleted += OnAllQuestsInDayCompleted;
        }

        private void Start()
        {
            _musicController.PlayMainAmbience();
            _questDays[0].Init();
            DayStarted?.Invoke();
        }

        public void StartNextDay()
        {
            Day++;         
            _musicController.PlayMainAmbience();
            _questDays[Day].Init();
            _questDays[Day].AllQuestsCompleted += OnAllQuestsInDayCompleted;
            DayStarted?.Invoke();
        }
        
        private void OnAllQuestsInDayCompleted()
        {
            _questDays[Day].AllQuestsCompleted -= OnAllQuestsInDayCompleted;
            _musicController.StopPlayingMainAmbience();
            DayCompleted?.Invoke();
            if (Day == _questDays.Count - 1)
            {
                AllDaysCompleted?.Invoke();
            }
        }
    }
}