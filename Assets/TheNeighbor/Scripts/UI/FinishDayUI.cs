using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Trellcko.UI
{
    public class FinishDayUI : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        [SerializeField] private TextMeshProUGUI _dayText;

        [Header("Animation")] [SerializeField] private float _showTime = 0.9f;
        [SerializeField] private float _hideTime = 0.9f;
        [SerializeField] private float _waitTime = 0.3f;

        private const string Day = "Day ";

        private Sequence _sequence;

        public void Show(int day, Action callback = null)
        {
            _sequence?.Kill();
            _canvasGroup.alpha = 0;           
            if(day < 0)
                _dayText.SetText("");
            else
            {
                _dayText.SetText(Day + day);
            }
            _sequence = DOTween.Sequence();
            _sequence.Append(ShowTween()).OnComplete(()=>callback?.Invoke());
        }

        public void Hide(Action callback = null)
        {
            _sequence?.Kill();
            _canvasGroup.alpha = 1;
            _sequence = DOTween.Sequence();
            _sequence.Append(HideTween().SetDelay(_waitTime)).OnComplete(()=>callback?.Invoke());
        }

        public void ShowAndHide(int day, Action callback = null)
        {
            _sequence?.Kill();
            _canvasGroup.alpha = 0;
            if(day < 0)
               _dayText.SetText("");
            else
            {
                _dayText.SetText(Day + day);
            }

            _sequence = DOTween.Sequence();
            _sequence.Append(ShowTween()).Append(HideTween().SetDelay(_waitTime)).OnComplete(()=>callback?.Invoke());
        }

        private Tween ShowTween() => _canvasGroup.DOFade(1, _showTime);
        private Tween HideTween() => _canvasGroup.DOFade(0, _hideTime);
    }
    
}