using System.Collections.Generic;
using UnityEngine;
using Version1.DTOs;
using Version1.Shared;
using Version1.Views;

namespace Version1.Controllers
{
    public class SpawnShapeController
    {
        private MatrixControllerDto _matrixControllerDto;
        private MatrixController _matrixController;
        private Shape _savedShape;
        private List<Vector2Int> _positions;

        public Shape SavedShape => _savedShape;
        public List<Vector2Int> Positions => _positions;
        public event ReturnShape OnSpawnShape;
        public event ReturnVoid OnFullMatrix;
        public Shape GetRandomShape()
        {
            int range = Random.Range(0, 7);
            switch (range)
            {
                case 0: return Shape.I;
                case 1: return Shape.T;
                case 2: return Shape.J;
                case 3: return Shape.L;
                case 4: return Shape.O;
                case 5: return Shape.S;
                case 6: return Shape.Z;
            }
            return null;
        }

        public List<Vector2Int> ShapeImageToMatrixPositions(Shape shape, Vector2Int spawnVector2Int)
        {
            List<Vector2Int> positions = new List<Vector2Int>();
            for (var i = 0; i < shape.Image.Count; i++)
            {
                for (var j = 0; j < shape.Image[i].Count; j++)
                {
                    if (shape.Image[i][j] == 1)
                    {
                        positions.Add(new Vector2Int(spawnVector2Int.X + j, spawnVector2Int.Y + i));
                    }
                }
            }

            return positions;
        }

        public SpawnShapeController(MatrixController matrixController,MatrixControllerDto matrixControllerDto)
        {
            _matrixControllerDto = matrixControllerDto;
            _matrixController = matrixController;
        }
        public void SpawnRandomShape()
        {
            _savedShape= GetRandomShape();
            _positions = ShapeImageToMatrixPositions(_savedShape, new Vector2Int(3 ,0));
            List<PointView> pointViews = new List<PointView>();
            foreach (var point in _positions)
            {
                if (_matrixController.CheckMatrixValue(point, 2))
                {
                    OnFullMatrix?.Invoke();
                    return;
                }
                PointView instantiate = Object.Instantiate(_matrixControllerDto.Prefab);
                pointViews.Add(instantiate);
                instantiate.Init(new PointViewDto(_matrixControllerDto, _savedShape.Color), point);
                
            }
            OnSpawnShape?.Invoke(_savedShape);
            _matrixController.SpawnPoints(pointViews);
        }
    }
}
