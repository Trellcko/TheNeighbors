using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.Monster
{
    public class MonsterInstaller : MonoInstaller
    {
        [SerializeField] private MonsterContainer _monsterContainer;

        public override void InstallBindings()
        {
            Container.Bind<MonsterContainer>().FromInstance(_monsterContainer).AsSingle();
        }
    }
}