using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnOffLight : MonoBehaviour
{
    [SerializeField] private List<GameObject> lights;

    [SerializeField] private GameObject teleport;
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject cameraRotation;

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            lights[0].gameObject.SetActive(!lights[0].activeSelf);
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            lights[1].gameObject.SetActive(!lights[1].activeSelf);
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            lights[2].gameObject.SetActive(!lights[2].activeSelf);
        }
        else if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            lights[3].gameObject.SetActive(!lights[3].activeSelf);
        }
        else if(Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            monster.transform.position = teleport.transform.position;
        }
        else if (Keyboard.current.digit6Key.wasPressedThisFrame)
        {
            cameraRotation.SetActive(!cameraRotation.activeSelf);
        }
    }
}
