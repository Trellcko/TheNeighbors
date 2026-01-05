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

        public void PlayOst(Ost ost)
        {
            _ambienceAudioSource.loop = true;
            _ambienceAudioSource.clip = _ambiences.First(x => x.Ost == ost).Clip;
            _ambienceAudioSource.Play();
        }

        public void PlayMonsterSound(MonsterSound monsterSound)
        {
            _monsterSoundAudioSource.clip = _monsterSound.First(x => x.Sound == monsterSound).Clip;
            _monsterSoundAudioSource.Play();
        }

        public void PlayShockMoment()
        {
            _ambienceAudioSource.loop = false;
            _ambienceAudioSource.clip = _shockMoment;
            _ambienceAudioSource.Play();
        }

        public void StopPlayingAmbience()
        {
            _ambienceAudioSource.Stop();
        }
    }
}