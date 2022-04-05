using UnityEngine;
using Version1.DTOs;

namespace Version1.Views
{
    public class PointView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private Vector2Int _vector2Int;
        public Vector2Int Vector2Int => _vector2Int;
        private PointViewDto _pointViewDto;
        public void Init(PointViewDto pointViewDto, Vector2Int startVector2Int)
        {
            _spriteRenderer.color = pointViewDto.Color;
            _pointViewDto = pointViewDto;
            UpdatePosition(startVector2Int);
        }
        public void UpdatePosition(Vector2Int vector2Int)
        {
            _vector2Int = vector2Int;
            transform.position = new Vector3(_pointViewDto.StartX + _pointViewDto.DeltaX * vector2Int.X,
                _pointViewDto.StartY - _pointViewDto.DeltaY * vector2Int.Y);
        }
    }
}
