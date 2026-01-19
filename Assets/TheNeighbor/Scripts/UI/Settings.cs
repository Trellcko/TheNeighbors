using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private Slider _music;
    [SerializeField] private Slider _sound;

    
    private void OnEnable()
    {
        _music.onValueChanged.AddListener(UpdateMusic);
        _sound.onValueChanged.AddListener(UpdateSound);
    }

    private void OnDisable()
    {
        _music.onValueChanged.RemoveListener(UpdateMusic);
        _sound.onValueChanged.RemoveListener(UpdateSound);
    }

    private void UpdateMusic(float musicValue)
    {
        _audioMixer.SetFloat("Music", musicValue);
    }

    private void UpdateSound(float soundValue)
    {
        _audioMixer.SetFloat("Sounds", soundValue);
    }
}
