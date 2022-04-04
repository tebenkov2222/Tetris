using UnityEngine;
namespace Version2.View
{
    public class PointView : MonoBehaviour
    {
        [SerializeField] private Color _enableColor;
        [SerializeField] private Color _disableColor;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public void View(bool value)
        {
            _spriteRenderer.color = value ? _enableColor : _disableColor;
        }
    }
}