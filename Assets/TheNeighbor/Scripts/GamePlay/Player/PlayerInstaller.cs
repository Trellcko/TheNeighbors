using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerFacade _player;

        public override void InstallBindings()
        {
            Container.Bind<PlayerFacade>().FromInstance(_player);
        }
    }
}