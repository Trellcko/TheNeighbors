using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Trellcko.UI
{
    [RequireComponent(typeof(Button))]
    public class LoadGameButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(LoadGameScene);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(LoadGameScene);
        }

        private void LoadGameScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}