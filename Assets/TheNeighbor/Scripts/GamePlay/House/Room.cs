using System.Collections.Generic;
using UnityEngine;

namespace Trellcko.Gameplay.House
{
   public class Room : MonoBehaviour
   {
      [SerializeField] private List<RoomPreset> _presets;

      public void SetPreset(int index)
      {
         foreach (RoomPreset preset in _presets)
         {
            preset.Object.localPosition = preset.Position[index];
            preset.Object.localRotation = Quaternion.Euler(preset.Rotation[index]);
         }
      }
   }
}