using UnityEngine;

namespace Trellcko.Gameplay.QuestLogic
{
    public class UpdateSpriteAndSoundResetObject : ResetObject
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private Texture _sprite;
        private static readonly int BaseMap = Shader.PropertyToID("_BaseMap");


        public override void Reset()
        {
            _meshRenderer.material.SetTexture(BaseMap, _sprite);
            _audioSource.clip = _audioClip;

        }
    }
}