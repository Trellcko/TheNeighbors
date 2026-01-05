using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public class ChangeMaterialColorResetObject : ResetObject
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Color _color;
        
        public override void Reset()
        {
            _meshRenderer.material.color = _color;
        }
    }
}