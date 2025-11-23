using System;
using UnityEngine;
using Zenject;

namespace Trellcko.Gameplay
{
    public class LookAtPlayer : MonoBehaviour
    {
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
                
                transform.rotation = Quaternion.LookRotation(dir) *  Quaternion.Euler(0, 180, 0);
            }
        }
    }
}