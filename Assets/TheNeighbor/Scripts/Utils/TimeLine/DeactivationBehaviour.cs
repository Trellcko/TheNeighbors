using UnityEngine;
using UnityEngine.Playables;

namespace Trellcko.Utils.Timeline
{
    public class DeactivationBehaviour : PlayableBehaviour
    {
        public bool ActivateAfter;
        
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
                GameObject target = playerData as GameObject;
         
                if(!target)
                    return;
                target.SetActive(false);
        }
        
        
    }
}