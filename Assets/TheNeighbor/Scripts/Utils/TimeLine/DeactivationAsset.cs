using System;
using UnityEngine;
using UnityEngine.Playables;

namespace Trellcko.Utils.Timeline
{
    [Serializable]
    public class DeactivationAsset : PlayableAsset
    {
        public bool ActivateAfter = true;
        
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            ScriptPlayable<DeactivationBehaviour> scriptPlayable = ScriptPlayable<DeactivationBehaviour>.Create(graph);
            scriptPlayable.GetBehaviour().ActivateAfter = ActivateAfter;
            return scriptPlayable;
        }
    }
}