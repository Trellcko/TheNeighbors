using Trellcko.Gameplay.QuestLogic;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
   public class DisableMeshAndColliderResetObject : ResetObject
   {
      [SerializeField] private Collider _collider;
      [SerializeField] private MeshRenderer _meshRenderer;


      public override void Reset()
      {
         _collider.enabled = false;
         _meshRenderer.enabled = false;
      }
   }
}