using System.Collections.Generic;
using UnityEngine;
using Version1.DTOs;
using Version1.Shared;
using Version1.Views;

namespace Version1
{
    public class MatrixController
    {
        private List<Vector2Int> _updatePoint;
        private List<List<byte>> _matrix;
        private List<List<PointView>> _matrixView;

        public List<List<byte>> Matrix => _matrix;
        public List<List<PointView>> MatrixView
        {
            get => _matrixView;
            private set => _matrixView = value;
        }

        private MatrixControllerDto _matrixControllerDto;
        public MatrixController(MatrixControllerDto matrixControllerDto)
        {
            _updatePoint = new List<Vector2Int>();
            _matrix = new List<List<byte>>();
            MatrixView = new List<List<PointView>>();
            for (int i = 0; i < matrixControllerDto.SizeY; i++)
            {
                _matrix.Add(new List<byte>());
                MatrixView.Add(new List<PointView>());
                for (int j = 0; j < matrixControllerDto.SizeX; j++)
                {
                    _matrix[i].Add(0);
                    MatrixView[i].Add(null);
                }
            }
        }

        public void SpawnPoints(List<PointView> points)
        {
            foreach (var point in points)
            {
                SetMatrixViewValue(point.Vector2Int,point);
                SetMatrixValue(point.Vector2Int, 1);
            }
        }
        public void UpdateMatrix(List<Vector2Int> lastPosition, List<Vector2Int> nextPosition)
        {
            _updatePoint.Clear();
            Dictionary<Vector2Int, PointView> pointViews = new Dictionary<Vector2Int, PointView>();
            for (var i = 0; i < lastPosition.Count; i++)
            {
                var lastPos = lastPosition[i];
                SetMatrixValue(lastPos, 0);
                GetMatrixViewValue(lastPos).UpdatePosition(nextPosition[i]);
                pointViews.Add(lastPos, GetMatrixViewValue(lastPos));
                SetMatrixViewValue(lastPos, null);
            }
            for (var i = 0; i < lastPosition.Count; i++)
            {
                SetMatrixValue(nextPosition[i],1);
                SetMatrixViewValue(nextPosition[i], pointViews[lastPosition[i]]);
            }
        }

        public void StayShape(List<Vector2Int> points)
        {
            foreach (var point in points)
            {
                SetMatrixValue(point, 2);
            }
        }

        public bool CheckMatrixValue(Vector2Int vector2Int, byte value)
        {
            return GetMatrixValue(vector2Int) == value;
        }

        public byte GetMatrixValue(Vector2Int vector2Int)
        {
            return _matrix[vector2Int.Y][vector2Int.X];
        }

        public void SetMatrixValue(Vector2Int vector2Int, byte value)
        {
            _matrix[vector2Int.Y][vector2Int.X] = value;
        }

        public void MovePoint(Vector2Int startPosition, Vector2Int endPosition)
        {
            SetMatrixValue(endPosition,GetMatrixValue(startPosition));
            SetMatrixViewValue(endPosition,GetMatrixViewValue(startPosition));
            if(GetMatrixValue(endPosition) == 2)GetMatrixViewValue(endPosition).UpdatePosition(endPosition);
        }
        public PointView GetMatrixViewValue(Vector2Int vector2Int)
        {
            return MatrixView[vector2Int.Y][vector2Int.X];
        }
        public void SetMatrixViewValue(Vector2Int vector2Int, PointView value)
        {
            MatrixView[vector2Int.Y][vector2Int.X] = value;
        }
    }
}