using UnityEngine;

namespace Trellcko.Gameplay.Trigger
{
    public class Day2MessTrigger : BaseTrigger
    {
        [SerializeField] private GameObject[] _mess;
        [SerializeField] private GameObject _monster;
        [SerializeField] private Transform _monsterPoint;
        
        [SerializeField] private Light _light;
        
        protected override void OnMakeVisible()
        {
            foreach (GameObject mess in _mess)
            {
                mess.SetActive(true);
            }
            
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
            _light.enabled = false;
        }
    }
}