using UnityEngine;
using Zenject;

namespace Trellcko.UI
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private FinishDayUI _finishDayUI;
        [SerializeField] private GameUI _gameUI;

        public override void InstallBindings()
        {
            Container.Bind<FinishDayUI>().FromInstance(_finishDayUI);
            Container.Bind<GameUI>().FromInstance(_gameUI);
        }
    }
}