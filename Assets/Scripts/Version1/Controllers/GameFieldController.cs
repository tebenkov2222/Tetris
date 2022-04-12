using System.Collections.Generic;
using UnityEngine;
using Version1.Shared;
using Version1.Views;

namespace Version1.Controllers
{
    public class GameFieldController
    {
        private PointController[,] _field;

        public PointController[,] Field => _field;
        private GameFieldView _gameFieldView;
        public Vector2Int Size => _size;
        private Vector2Int _size;

        public GameFieldController(GameFieldView gameFieldView)
        {
            _gameFieldView = gameFieldView;
            _size = gameFieldView.Size;
            _field = new PointController[_size.Y, _size.X];
            for (var i = 0; i < _size.Y; i++)
            {
                for (var j = 0; j < _size.X; j++)
                {
                    _field[i, j] = new PointController();
                }
            }
        }
        public void SpawnPoints(List<Vector2Int> points, Color color)
        {
            foreach (var point in points)
            {
                SetPointValue(point, PointStatus.Moved);
                _gameFieldView.SpawnPoint(point, color);
            }
        }

        public void DeletePoints(List<Vector2Int> points)
        {
            foreach (var point in points)
            {
                //Debug.Log($"point = {point} size = {_size}");
                DeletePoint(point);
            }
        }

        public void DeletePoint(Vector2Int point)
        {
            if(CheckPointValue(point,PointStatus.None)) return;
            SetPointValue(point,PointStatus.None);
            _gameFieldView.DeletePoint(point);
        }
        public void MovePoints(List<(Vector2Int, Vector2Int)> lastAndNewPositionPoint)
        {
            foreach (var (lastPos, nextPos) in lastAndNewPositionPoint)
            {
                _gameFieldView.MovePointView(lastPos, nextPos);
                SetPointValue(lastPos, 0);
            }
            foreach (var (lastPos, nextPos) in lastAndNewPositionPoint)
            {
                SetPointValue(nextPos, PointStatus.Moved);
            }
            _gameFieldView.UpdatePoints(lastAndNewPositionPoint);
        }
        public void MovePoint(Vector2Int startPoint, Vector2Int endPoint)
        {
            if(GetPointValue(startPoint) == PointStatus.None) return;
            _gameFieldView.MovePointView(startPoint, endPoint);
            SetPointValue(endPoint, GetPointValue(startPoint));
            SetPointValue(startPoint, 0);
            _gameFieldView.UpdatePoint(startPoint, endPoint);
        }
        public bool CheckPointValue(Vector2Int vector2Int, PointStatus value)
        {
            return GetPoint(vector2Int).PointStatus == value;
        }
        public bool CheckPointValue(Vector2Int vector2Int, int value)
        {
            return GetPoint(vector2Int).PointStatus == (PointStatus)value;
        }
        public PointController GetPoint(Vector2Int point)
        {
            return _field[point.Y,point.X];
        }
        public PointStatus GetPointValue(Vector2Int point)
        {
            return GetPoint(point).PointStatus;
        }
        public void SetPoint(Vector2Int vector2Int, PointController point)
        {
            _field[vector2Int.Y,vector2Int.X] = point;
        }
        public void SetPointValue(Vector2Int point, PointStatus value)
        {
            _field[point.Y,point.X].SetPointStatus(value);
        }
    }
}
