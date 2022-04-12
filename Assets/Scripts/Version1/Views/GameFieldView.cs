using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Version1.Controllers;
using Version1.Shared;

namespace Version1.Views
{
    public class GameFieldView: MonoBehaviour
    {
        [SerializeField] private Vector2Int _size;
        [SerializeField] private Vector2 _startPosition;
        [SerializeField] private Vector2 _deltaPosition;
        [SerializeField] private PointView _prefab;
        [SerializeField] private Transform _parrentTransform;
        private PointView[,] _fieldView;
        private MatrixOperations _matrixOperations;
        private Dictionary<Vector2Int, PointView> _pointViews;

        public Vector2Int Size => _size;

        public PointView[,] FieldView
        {
            get => _fieldView;
            private set => _fieldView = value;
        }

        public void Init()
        {
            FieldView = new PointView[_size.Y, _size.X];
            _matrixOperations = new MatrixOperations(_startPosition, _deltaPosition);
            _pointViews = new Dictionary<Vector2Int, PointView>();
        }

        public void DeletePoint(Vector2Int point)
        {
            Destroy(GetMatrixViewValue(point).gameObject);
            SetMatrixViewValue(point, null);
        }
        public PointView GetMatrixViewValue(Vector2Int vector2Int)
        {
            return FieldView[vector2Int.Y,vector2Int.X];
        }
        public void SetMatrixViewValue(Vector2Int vector2Int, PointView value)
        {
            FieldView[vector2Int.Y,vector2Int.X] = value;
        }

        public void MovePointView(Vector2Int startPosition, Vector2Int endPosition)
        {
            GetMatrixViewValue(startPosition).UpdatePosition(_matrixOperations.MatrixPositionToGlobalPosition(endPosition));
        }

        public void SpawnPoint(Vector2Int pointPosition, Color color)
        {
            var pointView = Instantiate(_prefab, _parrentTransform);
            pointView.Init(color,_matrixOperations.MatrixPositionToGlobalPosition(pointPosition));
            pointView.SetEnable(true);
            SetMatrixViewValue(pointPosition, pointView);
        }
        public void UpdatePoints(List< (Vector2Int, Vector2Int) > positions)
        {
            _pointViews.Clear();
            foreach (var (startPosition, endPosition) in positions)
            {
                _pointViews.Add(startPosition,GetMatrixViewValue(startPosition));
                SetMatrixViewValue(startPosition, null);
            }
            foreach (var (startPosition, endPosition) in positions)
            {
                SetMatrixViewValue(endPosition, _pointViews[startPosition]);
            }
        }
        public void UpdatePoint(Vector2Int startPosition, Vector2Int endPosition)
        {
            PointView value = GetMatrixViewValue(startPosition);
            SetMatrixViewValue(startPosition, null);
            SetMatrixViewValue(endPosition, value);
        }
    }
}
