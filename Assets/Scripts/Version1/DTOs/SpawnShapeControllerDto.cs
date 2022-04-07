
using Version1.Views;

namespace Version1.DTOs
{
    public struct SpawnShapeControllerDto
    {
        public PointView Prefab;

        public SpawnShapeControllerDto(PointView prefab, float startX, float startY, float deltaX, float deltaY)
        {
            Prefab = prefab;
        }
    }
}
