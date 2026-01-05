using UnityEngine;
using Zenject;

namespace Trellcko.Core.Audio
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private MainSoundController _mainSoundController;
        
        public override void InstallBindings()
        {
            Container.Bind<ISoundController>().FromInstance(_mainSoundController).AsSingle();
        }
    }
}