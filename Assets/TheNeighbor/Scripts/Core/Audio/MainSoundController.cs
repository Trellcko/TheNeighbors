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

        private Ost _lastOst;
        
        public void PlayOst(Ost ost)
        {
            _lastOst = ost;
            _ambienceAudioSource.loop = true;
            _ambienceAudioSource.clip = _ambiences.First(x => x.Ost == ost).Clip;
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
            PlayOst(_lastOst);
        }

        public void StopPlayingAmbience()
        {
            _ambienceAudioSource.Stop();
        }
    }
}