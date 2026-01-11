using System;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;

namespace Trellcko.Gameplay.Player
{
    [Serializable]
    public class ItemToBring
    {
        public Texture Sprite;
        public QuestItem Item;
        public Vector3 Offset;
    }
}