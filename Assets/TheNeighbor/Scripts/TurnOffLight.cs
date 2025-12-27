using Trellcko.Gameplay.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnOffLight : MonoBehaviour
{
    [SerializeField] private TurnOffTheLightForTimeEvent _bedRoom;
    [SerializeField] private TurnOnTelevisionEvent _television;
    [SerializeField] private TurnOffTelevisionEvent _television2;
    [SerializeField] private OpenTheDoorEvent _openDoor;
    [SerializeField] private PlaySoundEvent _playSoundKnock;
    [SerializeField] private PlaySoundEvent _playCroaksound;

    [SerializeField] private GameObject _monster;
    [SerializeField] private Transform _teleport;
    
    private void Update()
    {
        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            _television.MakeVisible();
        }
        else if (Keyboard.current.numpad2Key.wasPressedThisFrame)
        {
            _television2.MakeVisible();
            _playSoundKnock.MakeVisible();
        }
        else if (Keyboard.current.numpad3Key.wasPressedThisFrame)
        {
            _bedRoom.MakeVisible();
            _openDoor.MakeVisible();
        }
        else if (Keyboard.current.numpad4Key.wasPressedThisFrame)
        {
            _playCroaksound.MakeVisible();
        }
        else if (Keyboard.current.numpad5Key.wasPressedThisFrame)
        {
            _monster.transform.position = _teleport.position;
        }
    }
}
