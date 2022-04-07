using UnityEngine;
using Version1.DTOs;

namespace Version1.Views
{
    public class PointView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public void Init(Color color, Vector3 startPosition)
        {
            _spriteRenderer.color = color;
            UpdatePosition(startPosition);
        }
        public void SetEnable(bool isEnabled)
        {
            gameObject.SetActive(isEnabled);   
        }
        public void UpdatePosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
