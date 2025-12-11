using Trellcko.Gameplay.QuestLogic;
using UnityEngine;

public class EnableMeshAndColliderResetObject : ResetObject
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Collider _collider;
    
    public override void Reset()
    {
        _collider.enabled = true;
        _meshRenderer.enabled = true;
    }
}


