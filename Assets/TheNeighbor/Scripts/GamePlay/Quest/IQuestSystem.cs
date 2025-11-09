using System;

namespace Trellcko.Gameplay.QuestLogic
{
    public interface IQuestSystem
    {
        QuestsDayList CurrentDayList { get; }
        int Day { get; }
        event Action DayCompleted;
        event Action DayStarted;
        event Action AllDaysCompleted;
    }
}