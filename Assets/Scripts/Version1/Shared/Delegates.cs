using System.Collections.Generic;

namespace Version1.Shared
{
    public delegate void ReturnVoid();
    public delegate void ReturnListPositions(List<Vector2Int> positions);
    public delegate void ReturnShape(Shape shape);
}