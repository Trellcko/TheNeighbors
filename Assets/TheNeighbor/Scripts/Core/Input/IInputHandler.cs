using System;
using UnityEngine;

namespace Trellcko.Core.Input
{
    public interface IInputHandler
    {
        Vector2 GetMoveVector();
        Vector2 GetMouseDelta();
        event Action<Vector2> MouseMoved;
    }
}