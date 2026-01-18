using Trellcko.Gameplay.QuestLogic;
using UnityEngine;

public class PositionReseting : ResetObject
{
    [SerializeField] private Vector3 _localPosition;
    public override void Reset()
    {
        transform.position = _localPosition;
    }
}
