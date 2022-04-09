using UnityEngine;

namespace Version1.Views
{
    public class PointView : MonoBehaviour
    {
        private byte _value;

        public byte Value => _value;
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

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
