using Trellcko.Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.Monster
{
    public class MonsterFacade : MonoBehaviour
    {
        [field: SerializeField] public Bringing Bringing { get; private set; }
    }
}