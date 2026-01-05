using System;

namespace CastleWarriors.GameLogic.Utils
{
    public static class EnumExtension
    {
        public static T GetRandomEnum<T>() where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        }
    }
}