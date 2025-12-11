using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public class DefaultBedResetting : ResetObject
    {
        [SerializeField] private MeshRenderer _bedMesh;
        [SerializeField] private Material _badBedMaterial;
        [SerializeField] private Collider _collider;
        public override void Reset()
        {
            Material[] materials = _bedMesh.materials;
            materials[2] = _badBedMaterial;
            _bedMesh.sharedMaterials= materials;
            _collider.enabled = true;
        }
    }
}