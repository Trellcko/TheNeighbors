using Trellcko.Core.Audio;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay.Trigger
{
    public class Day2MessTrigger : BaseTrigger
    {
        [SerializeField] private GameObject[] _mess;
        [SerializeField] private GameObject _monster;
        [SerializeField] private Transform _monsterPoint;
        
        [SerializeField] private Light[] _lights;
        [SerializeField] private Light _lightAtTheEnd;
        private IMusicController _musicController;

        [Inject]
        private void Construct(IMusicController musicController)
        {
            _musicController = musicController;
        }

        protected override void OnBeforeActivate()
        {
            _musicController.PlayShockMoment();
        }

        protected override void OnMakeVisible()
        {
            foreach (GameObject mess in _mess)
            {
                mess.SetActive(true);
            }
            _lightAtTheEnd.enabled = false;
            _monster.SetActive(true);
            _monster.transform.position = _monsterPoint.position;
        }

        protected override void OnActivate()
        {
            foreach (GameObject mess in _mess)
            {
                mess.SetActive(false);
            }
            _monster.SetActive(false);
            _monster.transform.position = _monsterPoint.position;
            foreach (Light light1 in _lights)
            {
                light1.enabled = false;   
            }
        }
    }
}