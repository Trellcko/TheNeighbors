using DG.Tweening;
using UnityEngine;

namespace Trellcko.Gameplay
{
    public class BreathingAnimation : MonoBehaviour
    {
        [SerializeField] private float _factor;
        [SerializeField] private float _breatheInTime;
        [SerializeField] private float _breatheOutTime;
        [SerializeField] private float _delay;

        private Vector3 _startScale;
        private Vector3 _endScale;

        private Sequence _sequence;
        
        private void Awake()
        {
            _startScale = transform.localScale;
            _endScale = _startScale * _factor;
        }

        private void Start()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOScale(_endScale, _breatheInTime)
                    .SetEase(Ease.Linear))
                .AppendInterval(_delay)
                .Append(transform.DOScale(_startScale, _breatheOutTime)
                    .SetEase(Ease.Linear))
                .AppendInterval(_delay)
                .SetLoops(-1);
        }
    }
}