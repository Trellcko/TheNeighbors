using System;
using System.Collections.Generic;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    [Serializable]
    public class QuestDay
    {
        [field: SerializeField] public List<Quest> Quests { get; private set; }
        public Quest CurrentQuest => Quests[_questIndex];
        
        private int _questIndex = 0;

        public event Action AllQuestsCompleted;
        public event Action QuestCompleted;
        public event Action QuestActivated;

        public void Init()
        {
            foreach (Quest quest in Quests)
            {
                quest.Completed += OnQuestCompleted;
            }
            CurrentQuest.Activate();
            QuestActivated?.Invoke();
        }

        private void OnQuestCompleted()
        {
            CurrentQuest.Completed -= OnQuestCompleted;
            QuestCompleted?.Invoke();
            if (_questIndex == Quests.Count - 1)
            {
                AllQuestsCompleted?.Invoke();
                return;
            }
            _questIndex++;
            CurrentQuest.Activate();
            QuestActivated?.Invoke();
        }
    }
}