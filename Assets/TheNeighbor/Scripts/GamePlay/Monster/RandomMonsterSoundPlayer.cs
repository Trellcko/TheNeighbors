using System.Collections;
using CastleWarriors.GameLogic.Utils;
using Trellcko.Core.Audio;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Trellcko.Gameplay.Monster
{
    public class RandomMonsterSoundPlayer : MonoBehaviour
    {
        [SerializeField] private int _activationDay = 3;

        [SerializeField] private Vector2 _minMaxTime;

        private Coroutine _coroutine;
        
        private IQuestSystem _questSystem;
        private ISoundController _soundController;

        [Inject]
        private void Construct(IQuestSystem questSystem, ISoundController soundController)
        {
            _questSystem = questSystem;
            _soundController = soundController;
        }

        private void OnEnable()
        {
            _questSystem.DayStarted += OnDayStarted;
            _questSystem.DayCompleted += OnDayCompleted;
        }

        private void OnDisable()
        {
            _questSystem.DayStarted -= OnDayStarted;
            _questSystem.DayCompleted -= OnDayCompleted;
        }

        private void OnDayStarted()
        {
            if (_questSystem.Day == 3)
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }
                
                _coroutine = StartCoroutine(PlayRandomSoundsCorun());
            }
        }

        private void OnDayCompleted()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }

        private IEnumerator PlayRandomSoundsCorun()
        {
            float randomTime = Random.Range(_minMaxTime.x, _minMaxTime.y);

            while (true)
            {
                while (randomTime > 0)
                {
                    randomTime -= Time.deltaTime;
                    yield return null;
                }

                _soundController.PlayMonsterSound(EnumExtension.GetRandomEnum<MonsterSound>());
                randomTime = Random.Range(_minMaxTime.x, _minMaxTime.y);
            }
        }
    }
}