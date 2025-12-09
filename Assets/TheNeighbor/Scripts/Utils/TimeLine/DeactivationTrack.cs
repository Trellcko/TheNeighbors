using UnityEngine;
using UnityEngine.Timeline;

namespace Trellcko.Utils.Timeline
{
    [TrackClipType(typeof(DeactivationAsset))]
    [TrackBindingType(typeof(GameObject))]
    public class DeactivationTrack : TrackAsset
    {
    }
}