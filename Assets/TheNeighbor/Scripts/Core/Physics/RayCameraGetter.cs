using UnityEngine;

namespace Trellcko.Core.Physics
{
    public class RayCameraGetter : IRayGetter
    {
        private readonly Camera _camera;

        public RayCameraGetter(Camera camera)
        {
            _camera = camera;
        }
        
        public Ray GetRay() => 
            new(_camera.transform.position, _camera.transform.forward);
        
    }
}