using Trellcko.Core.Audio;
using Trellcko.Gameplay.Monster;
using Trellcko.Gameplay.Player;
using Trellcko.Gameplay.QuestLogic;
using Zenject;

namespace Trellcko.Gameplay.Events
{
    public class Day5StealMopEvent : BaseEvent
    {
        private ISoundController _soundController;
        private PlayerFacade _playerFacade;
        private MonsterFacade _monsterFacade;


        [Inject]
        private void Construct(PlayerFacade playerFacade, MonsterFacade monsterFacade, ISoundController soundController)
        {
            _soundController = soundController;
            _playerFacade = playerFacade;
            _monsterFacade = monsterFacade;
        }

        protected override void OnBeforeNotifierInvoked()
        {
            
        }

        protected override void OnMakeVisible()
        {
            _playerFacade.Bringing.SetItem(QuestItem.None);
            _soundController.PlayMonsterSound(MonsterSound.Laugh);
            _monsterFacade.Bringing.SetItem(QuestItem.Mop);
        }

        protected override void OnNotifierInvokeHandle()
        {
            throw new System.NotImplementedException();
        }
    }
}