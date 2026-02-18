using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light[] lights;

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            foreach (Light light in lights)
                light.enabled = !light.enabled;
        }
    }
}
