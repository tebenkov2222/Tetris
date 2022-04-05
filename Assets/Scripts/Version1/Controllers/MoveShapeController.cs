using System;
using System.Collections.Generic;
using App.Scripts.Shared.Inputs;
using UnityEngine;
using Version1.Shared;
using Button = App.Scripts.Shared.Inputs.Button;

namespace Version1.Controllers
{
    public class MoveShapeController
    {
        private List<Vector2Int> _positionsShape;
        private Vector2Int _centerPosition;
        private int _centerPointIndex;
        private bool _isSprint;
        private List<Vector2Int> _nextPositionsShape;
        private float _lastTime;
        private float _deltaTime = 1;
        private float _deltaTimeSprint = 0.1f;
        private bool _isCanMoved;
        private MatrixController _matrixController;
        public event ReturnVoid OnShapeStay;
        private int _sizeX;
        private int _sizeY;
        private IInput _input;

        public MoveShapeController(MatrixController matrixController, IInput input, int sizeX, int sizeY)
        {
            _centerPosition = new Vector2Int(-1, -1);
            _input = input;
            _input.ReturnButtonEvent += OnButtonChange;
            _matrixController = matrixController;
            _sizeX = sizeX;
            _sizeY = sizeY;
            _nextPositionsShape = new List<Vector2Int>();
            _positionsShape = new List<Vector2Int>();
            _isCanMoved = true;
        }

        private void OnButtonChange(Button button, ButtonState buttonstate)
        {
            switch (button)
            {
                case Button.Right:
                    if (!MoveTo(Vector2Int.Right)) return;
                    UpdateMatrix();
                    break;
                case Button.Left:
                    if (!MoveTo(Vector2Int.Left)) return;
                    UpdateMatrix();
                    break;
                case Button.Up:
                    if(!Rotate()) return;
                    UpdateMatrix();
                    break;
                case Button.Down:
                    _isSprint = buttonstate == ButtonState.OnPressed;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(button), button, null);
            }
        }

        public bool Rotate()
        {
            RecalculateCenterPosition();
            for (var i = 0; i < _positionsShape.Count; i++)
            {
                var deltaPosition = _positionsShape[i] - _centerPosition;
                _nextPositionsShape[i] = _centerPosition + new Vector2Int(deltaPosition.Y, -deltaPosition.X);
                if (!CheckRange(_nextPositionsShape[i]) || _matrixController.CheckMatrixValue(_nextPositionsShape[i], 2))
                {
                    return false;
                }
            }

            return true;
        }

        private void FindCenterPosition()
        {
            _centerPosition = new Vector2Int(0, 0);
            foreach (var i in _positionsShape)
            {
                _centerPosition += i;
            }

            _centerPosition /= _positionsShape.Count;
            for (var i = 0; i < _positionsShape.Count; i++)
            {
                if (_positionsShape[i] == _centerPosition)
                {
                    _centerPointIndex = i;
                    return;
                }
            }
        }

        private void RecalculateCenterPosition()
        {
            _centerPosition = _positionsShape[_centerPointIndex];
        }

        public void ChangeShape(List<Vector2Int> positions)
        {
            _lastTime = Time.time;
            _isCanMoved = true;
            _lastTime = Time.time;
            _positionsShape = new List<Vector2Int>(positions);
            FindCenterPosition();
            _nextPositionsShape.Clear();
            _nextPositionsShape.AddRange(positions);
            _centerPosition = new Vector2Int(-1, -1);
        }

        public void Fixed()
        {
            CheckMoveDown();
        }

        public void CheckMoveDown()
        {
            if(!_isCanMoved) return;
            if (!(Time.time - _lastTime > (_isSprint? _deltaTimeSprint:_deltaTime))) return;
            _lastTime = Time.time;
            if (!MoveTo(Vector2Int.Up))
            {
                _isCanMoved = false;
                _matrixController.StayShape(_positionsShape);
                OnShapeStay?.Invoke();
                return;
            }

            UpdateMatrix();
        }

        public void UpdateMatrix()
        {
            _matrixController.UpdateMatrix(_positionsShape,_nextPositionsShape);
            for (int i = 0; i < _positionsShape.Count; i++)
            {
                _positionsShape[i] = _nextPositionsShape[i];
            }
        }
        public bool MoveTo(Vector2Int direction)
        {
            for (var i = 0; i < _positionsShape.Count; i++)
            {
                _nextPositionsShape[i] = _positionsShape[i] + direction;
                if (!CheckRange(_nextPositionsShape[i]) || _matrixController.CheckMatrixValue(_nextPositionsShape[i], 2))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckRange(Vector2Int position)
        {
            return position.Y >= 0 && position.Y < _sizeY && position.X >= 0 && position.X < _sizeX;
        }
    }
}
