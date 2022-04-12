using UnityEngine;

namespace Version1.Shared
{
    public class MatrixOperations
    {
        private Vector2 _startPosition;
        private Vector2 _deltaPosition;

        public MatrixOperations(Vector2 startPosition, Vector2 deltaPosition)
        {
            _startPosition = startPosition;
            _deltaPosition = deltaPosition;
        }

        public Vector3 MatrixPositionToGlobalPosition(Vector2Int matrixPosition)
        {
            return new Vector3(
                _startPosition.x + _deltaPosition.x * matrixPosition.X,
                _startPosition.y - _deltaPosition.y * matrixPosition.Y); 
        }
    }
}
