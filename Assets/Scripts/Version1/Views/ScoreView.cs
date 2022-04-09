using UnityEngine;
using UnityEngine.UI;

namespace Version1.Views
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void SetValue(int value)
        {
            _text.text = value.ToString();
        }
    }
}
