using UnityEngine;

namespace Trellcko.Gameplay.Cinematic
{
    public class RedRoomCinematicEvent : MonoBehaviour
    {
        [SerializeField] private TVController _tvController;
        [SerializeField] private Light _light;
        [SerializeField] private BaseCinematic _baseCinematic;
        [SerializeField] private GameObject _monster;
        [SerializeField] private Transform _monsterSpawnPoint;


        public void Run()
        {
            _baseCinematic.Completed += OnCompleted;
            _tvController.TurnOnRedMode();
            _light.color = Color.red;
            _monster.transform.position = _monsterSpawnPoint.position;
            _monster.SetActive(true);
        }

        private void OnCompleted()
        {
            _tvController.TurnOff();
            _light.color = Color.white;
            _monster.SetActive(false);
        }
    }
}