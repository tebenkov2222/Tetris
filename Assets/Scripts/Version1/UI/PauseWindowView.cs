using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Version1.Shared;

namespace Version1.UI
{
    public class PauseWindowView : MonoBehaviour
    {
        private Button _resumeButton;
        private Button _settingsButton;
        private Button _menuButton;

        public event ReturnVoid OnResumePressed;
        public event ReturnVoid OnSettingsPressed;
        public event ReturnVoid OnMenuPressed;
        private UnityAction _resumeDelegate => delegate { OnResumePressed?.Invoke(); };
        private UnityAction _settingsDelegate => delegate { OnSettingsPressed?.Invoke(); };
        private UnityAction _menuDelegate => delegate { OnMenuPressed?.Invoke(); };

        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(_resumeDelegate);
            _settingsButton.onClick.AddListener(_settingsDelegate);
            _menuButton.onClick.AddListener(_menuDelegate);
        }

        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(_resumeDelegate);
            _settingsButton.onClick.RemoveListener(_settingsDelegate);
            _menuButton.onClick.RemoveListener(_menuDelegate);
        }
    }
}
