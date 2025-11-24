using System;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay
{
    public class LookAtPlayer : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        
        private PlayerFacade _playerFacade;
        
        [Inject]
        private void Construct(PlayerFacade playerFacade)
        {
            _playerFacade = playerFacade;
        }

        private void Update()
        {
            if (_playerFacade)
            {
                Vector3 dir = (_playerFacade.transform.position - transform.position).normalized;
                dir.y = 0;
                dir.Normalize();
                
                transform.rotation = Quaternion.LookRotation(dir) *  Quaternion.Euler(0, 180, 0) * Quaternion.Euler(_offset.x, _offset.y, _offset.z);
            }
        }
    }
}