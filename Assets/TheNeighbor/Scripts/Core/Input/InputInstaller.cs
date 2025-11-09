using Zenject;

namespace Trellcko.Core.Input
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputHandler>().To<InputHandler>().AsSingle();
        }
    }
}