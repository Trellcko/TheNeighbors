using System;
using System.Collections.Generic;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    [Serializable]
    public class ResetObjectData
    {
        [field: SerializeField] public List<ResetObject> Items { get; private set; }
    }
}