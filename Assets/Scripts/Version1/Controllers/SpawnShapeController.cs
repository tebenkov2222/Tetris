using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Version1.Core;
using Version1.DTOs;
using Version1.Shared;
using Version1.Views;

namespace Version1.Controllers
{
    public class SpawnShapeController
    {
        private PointView _prefab;
        public ShapeBase GetRandomShape()
        {
            int range = Random.Range(0, 7);
            switch (range)
            {
                case 0: return ShapeBase.I;
                case 1: return ShapeBase.T;
                case 2: return ShapeBase.J;
                case 3: return ShapeBase.L;
                case 4: return ShapeBase.O;
                case 5: return ShapeBase.S;
                case 6: return ShapeBase.Z;
            }
            return null;
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
                        positions.Add(new Vector2Int(spawnVector2Int.X + j, spawnVector2Int.Y + i));
                    }
                }
            }

            return positions;
        }

        public SpawnShapeController(PointView prefab)
        {
            _prefab = prefab;
        }
        public Shape SpawnRandomShape()
        {
            var randomShape= GetRandomShape();
            var points = ShapeImageToMatrixPositions(randomShape, new Vector2Int(3 ,0));
            List<PointView> pointViews = new List<PointView>();
            foreach (var instantiate in points.Select(point => Object.Instantiate(_prefab)))
            {
                pointViews.Add(instantiate);
                instantiate.Init(randomShape.Color, Vector3.zero);
                instantiate.SetEnable(false);
            }
            return new Shape(pointViews,points);
        }
    }
}
