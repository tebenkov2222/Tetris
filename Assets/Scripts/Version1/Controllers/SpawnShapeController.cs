using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Version1.Core;
using Version1.Views;

namespace Version1.Controllers
{
    public class SpawnShapeController
    {
        private System.Random _random;
        private PointView _prefab;

        public SpawnShapeController()
        {
            _random = new System.Random();
        }

        public ShapeBase GetRandomShape()
        {
            var range = _random.Next(0,7);
            return range switch
            {
                0 => ShapeBase.I,
                1 => ShapeBase.T,
                2 => ShapeBase.J,
                3 => ShapeBase.L,
                4 => ShapeBase.O,
                5 => ShapeBase.S,
                6 => ShapeBase.Z,
                _ => null
            };
        }

        public List<Vector2Int> ShapeImageToMatrixPositions(ShapeBase shapeBase, Vector2Int spawnVector2Int)
        {
            List<Vector2Int> positions = new List<Vector2Int>();
            for (var i = 0; i < shapeBase.Image.Count; i++)
            {
                for (var j = 0; j < shapeBase.Image[i].Count; j++)
                {
                    if (shapeBase.Image[i][j] == 1)
                    {
                        //Debug.Log(new Vector2Int(spawnVector2Int.X + j, spawnVector2Int.Y + i));
                        positions.Add(new Vector2Int(spawnVector2Int.X + j, spawnVector2Int.Y + i));
                    }
                }
            }

            return positions;
        }

        public Shape SpawnRandomShape()
        {
            var randomShape= GetRandomShape();
            var points = ShapeImageToMatrixPositions(randomShape, new Vector2Int(0 ,0));
            return new Shape(points, randomShape.Color);
        }
    }
}
