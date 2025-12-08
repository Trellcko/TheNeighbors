using UnityEngine;
using Zenject;

namespace Trellcko.UI
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private FinishDayUI _finishDayUI;

        public override void InstallBindings()
        {
            Container.Bind<FinishDayUI>().FromInstance(_finishDayUI);
        }
    }
}