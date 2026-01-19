using System;
using UnityEngine;

public class AnimationPositionBlocker : MonoBehaviour
{
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    void OnAnimatorMove()
    {
        transform.position = _startPosition; // де startPosition збережений в Awake
    }
}
