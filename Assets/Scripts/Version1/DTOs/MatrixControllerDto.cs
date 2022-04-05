using System;
using Version1.Views;

namespace Version1.DTOs
{ 
    [Serializable]
    public struct MatrixControllerDto
    {
        public PointView Prefab;
        public int SizeX;
        public int SizeY;
        public float StartX;
        public float StartY;
        public float DeltaX;
        public float DeltaY;

        public MatrixControllerDto(PointView prefab, int sizeX, int sizeY, float startX, float startY, float deltaX, float deltaY)
        {
            Prefab = prefab;
            SizeX = sizeX;
            SizeY = sizeY;
            StartX = startX;
            StartY = startY;
            DeltaX = deltaX;
            DeltaY = deltaY;
        }
    }
}
