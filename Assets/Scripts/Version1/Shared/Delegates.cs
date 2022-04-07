using System.Collections.Generic;
using Version1.Core;
using Version1.Views;

namespace Version1.Shared
{
    public delegate void ReturnVoid();
    public delegate void ReturnListVector2Int(List<Vector2Int> positions);
    public delegate void ReturnShapeBase(ShapeBase shapeBase);
    public delegate void ReturnShape(Shape shape);
    public delegate void ReturnInt(int value);
    public delegate void ReturnShapeAndPoints(Shape shape, List<PointView> points);
}