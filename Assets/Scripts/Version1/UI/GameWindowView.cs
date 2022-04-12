using UnityEngine;
using UnityEngine.UI;
using Version1.Shared;

namespace Version1.UI
{
    public class GameWindowView : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        public event ReturnVoid OnPause;
        private void Awake()
        {
            _pauseButton.onClick.AddListener(delegate { OnPause?.Invoke(); });
        }
    }
}
