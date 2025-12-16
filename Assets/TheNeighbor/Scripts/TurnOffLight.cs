using System;
using System.Collections.Generic;
using Trellcko.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnOffLight : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameobjects;
    [SerializeField] private AudioSource knocking;

    [SerializeField] private TVController _tvController;
    
    [SerializeField] private GameObject teleport;
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject cameraRotation;

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            foreach (var gameobject in _gameobjects)
            {
                gameobject.SetActive(true);
            }
        }
        
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            knocking.Play();
        }
        else if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            if(!_tvController.IsWorked)
                _tvController.TurnOn();
            else
                _tvController.TurnOff();
        }
        else if (Keyboard.current.digit8Key.wasPressedThisFrame)
        {
            cameraRotation.SetActive(!cameraRotation.activeSelf);
        }
    }
}
