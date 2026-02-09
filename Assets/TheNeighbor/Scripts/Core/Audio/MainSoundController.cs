using System.Collections;
using System.Linq;
using UnityEngine;

namespace Trellcko.Core.Audio
{
    public class MainSoundController : MonoBehaviour, ISoundController
    {
        [SerializeField] private AudioSource _ambienceAudioSource;
        [SerializeField] private AudioSource _monsterSoundAudioSource;
        
        [SerializeField] private OstData[] _ambiences;
        [SerializeField] private MonsterSoundData[] _monsterSound;
        [SerializeField] private AudioClip _shockMoment;
        public bool IsAmbiencPlaying => _ambienceAudioSource.isPlaying;
        public Ambience CurrentAmbience { get; private set; }

        public void PlayAmbience(Ambience ambience)
        {
            CurrentAmbience = ambience;
            _ambienceAudioSource.loop = true;
            _ambienceAudioSource.clip = _ambiences.First(x => x.ambience == ambience).Clip;
            _ambienceAudioSource.Play();
        }

        public void PlayMonsterSound(MonsterSound monsterSound)
        {
            _monsterSoundAudioSource.clip = _monsterSound.First(x => x.Sound == monsterSound).Clip;
            _monsterSoundAudioSource.Play();
        }

        public void PlayShockMoment(bool playAfterAmbien = false)
        {
            _ambienceAudioSource.loop = false;
            _ambienceAudioSource.clip = _shockMoment;
            _ambienceAudioSource.Play();
            if (playAfterAmbien)
            {
                StartCoroutine(PlayAmbienWhenFree());
            }
        }

        private IEnumerator PlayAmbienWhenFree()
        {
            while (_ambienceAudioSource.isPlaying)
            {
                yield return null;
            }
            PlayAmbience(CurrentAmbience);
        }

        public void StopPlayingAmbience()
        {
            _ambienceAudioSource.Stop();
        }
    }
}