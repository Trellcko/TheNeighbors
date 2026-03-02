using UnityEngine;
using Zenject;

namespace Trellcko.UI
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private TransitionUI transitionUI;
        [SerializeField] private GameUI _gameUI;

        public override void InstallBindings()
        {
            Container.Bind<TransitionUI>().FromInstance(transitionUI);
            Container.Bind<GameUI>().FromInstance(_gameUI);
        }
    }
}