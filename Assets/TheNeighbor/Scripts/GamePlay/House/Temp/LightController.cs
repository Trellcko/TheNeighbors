using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightController : MonoBehaviour
{
    [SerializeField] private GameObject _monster;

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            _monster.SetActive(!_monster.activeSelf);
        }
    }
}
