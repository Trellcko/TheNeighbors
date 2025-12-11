using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.QuestLogic
{
    public class QuestSystemInstaller : MonoInstaller
    {
        [SerializeField] private QuestSystem _questSystem;
        [SerializeField] private DayResetting _dayResetting;

        public override void InstallBindings()
        {
            Container.Bind<IQuestSystem>().FromInstance(_questSystem).AsSingle();
            Container.Bind<IDayResetting>().FromInstance(_dayResetting).AsSingle();
        }
    }
}