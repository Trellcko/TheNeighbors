using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public class LightResetting : ResetObject
    {
        [SerializeField] private Light _light;
        [SerializeField] private Color _lightColor = Color.white;
        public override void Reset()
        {
            _light.enabled = true;
            _light.color = _lightColor;
        }
    }
}