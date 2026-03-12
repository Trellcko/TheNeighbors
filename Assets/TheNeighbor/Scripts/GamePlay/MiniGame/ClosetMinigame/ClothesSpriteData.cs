using System;
using System.Collections.Generic;
using UnityEngine;

namespace Trellcko.Gameplay.MiniGame
{
    [Serializable]
    public class ClothesSpriteData
    {
        [SerializeField] private List<Sprite> _clothesSprites;
        [SerializeField] private List<Sprite> _corpsesSprites;

        public IReadOnlyList<Sprite> ClothesSprites => _clothesSprites;
        public IReadOnlyList<Sprite> CorpsesSprites => _corpsesSprites;
    }
}