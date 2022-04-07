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

        public PointViewDto( Color color, float startX, float startY, float deltaX, float deltaY)
        {
            Color = color;
            StartX = startX;
            StartY = startY;
            DeltaX = deltaX;
            DeltaY = deltaY;
        }
    }
}
