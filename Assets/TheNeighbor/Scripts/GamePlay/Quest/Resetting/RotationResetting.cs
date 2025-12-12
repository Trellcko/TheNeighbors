using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public class RotationResetting : ResetObject
    {
        [SerializeField] private Vector3 _defaultAngel;
        [SerializeField] private Transform _target;

        public override void Reset()
        {
            _target.localRotation = Quaternion.Euler(_defaultAngel);
        }
    }
}