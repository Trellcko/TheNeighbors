using System;
using Trellcko.Core.Input;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Trellcko.Gameplay.Player
{
    public class PlayerAudioStepsHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _walking;
        [SerializeField] private AudioClip _running;
        [SerializeField] private float _pinchMaxStep;
        [SerializeField] private float _timeToChangePinch = 1.26f;

        private IInputHandler _inputHandler;

        private bool _isPlayed;

        private float _time;
        
        [Inject]
        private void Inject(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }
        
        private void OnEnable()
        {
            _inputHandler.Moved += OnMoved;
            _inputHandler.MovedCanceled += OnMovedCanceled;
            _inputHandler.Sprint += OnSprintPerformed;
            _inputHandler.SprintCanceled += OnSprintCanceled;
        }

        private void OnDisable()
        {
            _inputHandler.Moved -= OnMoved;
            _inputHandler.MovedCanceled -= OnMovedCanceled;
            _inputHandler.Sprint -= OnSprintPerformed;
            _inputHandler.SprintCanceled -= OnSprintCanceled;
        }

        private void Update()
        {
            if(!_isPlayed)
                return;
            _time += Time.deltaTime;
            if (_time >= _timeToChangePinch)
            {
                _audioSource.pitch = Random.Range(1 - _pinchMaxStep, 1 + _pinchMaxStep);
            }
        }

        private void OnMovedCanceled()
        {
            if(_inputHandler.GetMoveVector().magnitude > 0) return;
            
            _isPlayed = false;
            _audioSource.Stop();
        }

        private void OnMoved(Vector2 obj)
        {
            if(_isPlayed) return;
            
            _time = 0f;
            _isPlayed = true;
            _audioSource.Play();
        }

        private void OnSprintCanceled()
        {
            if (_audioSource.clip != _walking)
                ChangeMainSound(_walking);
        }

        private void ChangeMainSound(AudioClip clip)
        {
            bool wasPlaying = _audioSource.isPlaying;
            _audioSource.clip = clip;
            if (wasPlaying)
            {
                _audioSource.Play();
            }
        }

        private void OnSprintPerformed()
        {
            ChangeMainSound(_running);
        }
    }
}