using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Trellcko.UI
{
    public class QuestUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _choreTask;
        [SerializeField] private GameObject _content;
        
        [Header("Animation")]
        [SerializeField] private float _strikethroughtTime = 0.2f;
        [SerializeField] private float _hideTime = 0.5f;
        [SerializeField] private float _showTime = 0.5F;

        private Sequence _sequence;
        
        public void Enable()
        {
            _content.SetActive(true);
        }

        public void Disable()
        {
            _content.SetActive(false);
        }

        public void ForceSetText(string text)
        {
            _sequence?.Kill();
            _choreTask.fontStyle = FontStyles.Bold;
            _choreTask.SetText(text);
        }

        public void SetTextWithAnimation(string text)
        {
            _choreTask.fontStyle = FontStyles.Bold | FontStyles.Strikethrough;
            _sequence = DOTween.Sequence();
            _sequence.Append(_choreTask.DOColor(Color.clear, _hideTime).OnComplete(()=>
                {
                    _choreTask.fontStyle = FontStyles.Bold;
                    _choreTask.SetText(text);
                }))
                .Append(_choreTask.DOColor(Color.white, _showTime)).SetDelay(_strikethroughtTime);
        }
    }
}