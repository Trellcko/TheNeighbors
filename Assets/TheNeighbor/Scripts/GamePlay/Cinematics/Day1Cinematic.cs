using Trellcko.Gameplay.Interactable;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;
using UnityEngine.Playables;

namespace Trellcko.Gameplay.Cinematic
{
    public class Day1Cinematic : BaseCinematic
    {
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private GameObject _cinematicCamera;
        
        public override void Play()
        {
            _playableDirector.Play();
            _playableDirector.stopped += OnStopped;
            InvokeCompleted();
        }

        private void OnStopped(PlayableDirector obj)
        {
            _playableDirector.stopped -= OnStopped;
            InvokeCompleted();
        }

        public override void DisableObjects()
        {
            _cinematicCamera.SetActive(false);
        }
    }
}