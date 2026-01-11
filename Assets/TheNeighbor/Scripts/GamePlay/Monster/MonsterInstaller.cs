using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.Monster
{
    public class MonsterInstaller : MonoInstaller
    {
        [SerializeField] private MonsterFacade _monsterFacade;

        public override void InstallBindings()
        {
            Container.Bind<MonsterFacade>().FromInstance(_monsterFacade).AsSingle();
        }
    }
}