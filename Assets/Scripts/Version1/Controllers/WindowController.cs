using UnityEngine;
using Version1.Core;
using Version1.DTOs;

namespace Version1.Controllers
{
    public class WindowController
    {
        private WindowControllerDto _windowControllerDto;

        public WindowController(WindowControllerDto windowControllerDto)
        {
            _windowControllerDto = windowControllerDto;
        }

        public void UpdateShape(Shape shape)
        {
            for (var i = 0; i < shape.Points.Count; i++)
            {
                shape.PointViews[i].UpdatePosition(MatrixPositionToGlobalPosition(shape.Points[i]));
                shape.PointViews[i].SetEnable(true);
            }
        }
        public Vector3 MatrixPositionToGlobalPosition(Vector2Int matrixPosition)
        {
            return new Vector3(
                _windowControllerDto.StartPosition.x + _windowControllerDto.DeltaPosition.x * matrixPosition.X,
                _windowControllerDto.StartPosition.y - _windowControllerDto.DeltaPosition.y * matrixPosition.Y);
        }
    }
}
