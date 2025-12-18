using UnityEngine;

namespace Trellcko.Core.Audio
{
    public class MusicController : MonoBehaviour, IMusicController
    {
        [SerializeField] private AudioSource _audioSource;
        
        [SerializeField] private AudioClip _mainAmbience;
        [SerializeField] private AudioClip _shockMoment;

        public void PlayMainAmbience()
        {
            _audioSource.loop = true;
            _audioSource.clip = _mainAmbience;
            _audioSource.Play();
        }

        public void PlayShockMoment()
        {
            _audioSource.loop = false;
            _audioSource.clip = _shockMoment;
            _audioSource.Play();
        }

        public void StopPlayingMainAmbience()
        {
            _audioSource.Stop();
        }
    }
}