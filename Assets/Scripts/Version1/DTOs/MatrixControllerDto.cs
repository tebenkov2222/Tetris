using System;
using UnityEngine;
using Version1.Views;

namespace Version1.DTOs
{ 
    [Serializable]
    public struct MatrixControllerDto
    {
        public PointView Prefab;
        public Vector2Int Size;
        public Vector2 StartPosition;
        public Vector2 DeltaPosition;

        public MatrixControllerDto(PointView prefab, Vector2Int size, Vector2 startPosition, Vector2 deltaPosition)
        {
            Prefab = prefab;
            StartPosition = startPosition;
            DeltaPosition = deltaPosition;
            Size =size;
        }
    }
}
