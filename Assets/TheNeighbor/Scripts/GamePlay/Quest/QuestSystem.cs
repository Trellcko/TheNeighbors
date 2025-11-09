using System;
using System.Collections.Generic;
using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public class QuestSystem : MonoBehaviour
    {
        [field: SerializeField] public List<QuestDay> QuestDays { get; set; }
        
        public int Day { get; private set; }

        private void Awake()
        {
            QuestDays[0].Init();
        }
    }
}