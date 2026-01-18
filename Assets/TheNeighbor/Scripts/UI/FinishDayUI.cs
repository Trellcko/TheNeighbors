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
        [SerializeField] private TextMeshProUGUI _showFinishGameUI;
        
        [Header("Animation")] [SerializeField] private float _showTime = 0.9f;
        [SerializeField] private float _hideTime = 0.9f;
        [SerializeField] private float _waitTime = 0.3f;

        private const string Day = "Day ";

        private Sequence _sequence;

        public void ShowFinishGameUI()
        {
            _sequence?.Kill(true);
            _dayText.SetText("");
            _showFinishGameUI.gameObject.SetActive(true);
            _canvasGroup.alpha = 0;           
            _sequence = DOTween.Sequence();
            _sequence.Append(ShowTween());
        }
        
        public void ShowUI(int day, Action callback = null)
        {
            _sequence?.Kill(true);
            if(day < 0)
                _dayText.SetText("");
            else
            {
                _dayText.SetText(Day + day);
            }
            _canvasGroup.alpha = 0;           
            _sequence = DOTween.Sequence();
            _sequence.Append(ShowTween()).OnComplete(()=>callback?.Invoke());
        }

        public void HideUI(Action callback = null)
        {
            _sequence?.Kill(true);
            _canvasGroup.alpha = 1;
            _sequence = DOTween.Sequence();
            _sequence.Append(HideTween().SetDelay(_waitTime)).OnComplete(()=>callback?.Invoke());
        }

        public void ShowAndHideUI(int day, Action callback = null)
        {
            _sequence?.Kill(true);
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