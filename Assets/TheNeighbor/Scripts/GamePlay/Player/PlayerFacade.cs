using UnityEngine;

namespace Trellcko.Gameplay.Player
{
  public class PlayerFacade : MonoBehaviour
  {
    [field: SerializeField] public PlayerMovement PlayerMovement { get; private set; }
    [field: SerializeField] public PlayerRotation PlayerRotation { get; private set; }
  }
}