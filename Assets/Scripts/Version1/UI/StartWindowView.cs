using UnityEngine;
using UnityEngine.UI;
using Version1.Shared;

namespace Version1.UI
{
    public class StartWindowView : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;
        
        public event ReturnVoid OnStart;
        public event ReturnVoid OnSettings;
        public event ReturnVoid OnExit;

        public void Show()
        {
            
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            _startButton.onClick.AddListener(delegate { OnStart?.Invoke(); });
            _settingsButton.onClick.AddListener(delegate { OnSettings?.Invoke(); });
            _exitButton.onClick.AddListener(delegate { OnExit?.Invoke(); });
        }

        private void OnDisable()
        {
            _startButton.onClick.AddListener(delegate { OnStart?.Invoke(); });
            _exitButton.onClick.AddListener(delegate { OnExit?.Invoke(); });
            _settingsButton.onClick.AddListener(delegate { OnSettings?.Invoke(); });
        }
    }
}
