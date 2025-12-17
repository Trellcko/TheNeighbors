using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public class LightResetting : ResetObject
    {
        [SerializeField] private Light _light;
        public override void Reset()
        {
            _light.enabled = true;
        }
    }
}