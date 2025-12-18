using UnityEngine;
using Zenject;

namespace Trellcko.Core.Audio
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private MusicController _musicController;
        
        public override void InstallBindings()
        {
            Container.Bind<IMusicController>().FromInstance(_musicController).AsSingle();
        }
    }
}