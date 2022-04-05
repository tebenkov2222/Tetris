using UnityEngine;

namespace Version1.DTOs
{
    public struct PointViewDto 
    {
        public float StartX;
        public float StartY;
        public float DeltaX;
        public float DeltaY;
        public Color Color;

        public PointViewDto(MatrixControllerDto matrixControllerDto, Color color)
        {
            StartX = matrixControllerDto.StartX;
            StartY = matrixControllerDto.StartY;
            DeltaX = matrixControllerDto.DeltaX;
            DeltaY = matrixControllerDto.DeltaY;
            Color = color;
        }
    }
}
