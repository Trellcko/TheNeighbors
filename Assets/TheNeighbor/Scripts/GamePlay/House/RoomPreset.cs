using System;
using System.Collections.Generic;
using UnityEngine;

namespace Trellcko.Gameplay.House
{
    [Serializable]
    public class RoomPreset
    {
        public Transform Object;
        public List<Vector3> Position;
        public List<Vector3> Rotation;
    }
}