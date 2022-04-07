using System;
using UnityEngine;

namespace Version1.DTOs
{ 
    [Serializable]
    public struct MatrixControllerDto
    {
        public Vector2Int Size;
        public Vector2 StartPosition;
        public Vector2 DeltaPosition;
    }
}
