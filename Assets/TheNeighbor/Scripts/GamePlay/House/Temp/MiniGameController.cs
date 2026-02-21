using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameController : MonoBehaviour
{
    [SerializeField] private Light[] _lights;
    [SerializeField] private GameObject _monster;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerHang;

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            _lights[0].enabled = _lights[1].enabled = false;
        }
        
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            _lights[0].enabled = _lights[1].enabled = true;
        }
        
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            _lights[0].color = _lights[1].color = Color.red;
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            _player.SetActive(!_player.activeSelf);
        }

        if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            _playerHang.SetActive(!_playerHang.activeSelf);
        }

        if (Keyboard.current.digit6Key.wasPressedThisFrame)
        {
            _monster.SetActive(!_monster.activeSelf);
        }
    }
}
