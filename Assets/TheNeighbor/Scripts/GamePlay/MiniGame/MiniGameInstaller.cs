using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.MiniGame
{
    public class MiniGameInstaller : MonoInstaller
    {
        [SerializeField] private MiniGamesController _miniGamesController;

        public override void InstallBindings()
        {
            Container.Bind<MiniGamesController>().FromInstance(_miniGamesController);
        }
    }
}