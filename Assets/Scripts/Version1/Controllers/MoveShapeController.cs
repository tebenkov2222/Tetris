using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Shared.Inputs;
using UnityEngine;
using Version1.Core;
using Button = App.Scripts.Shared.Inputs.Button;

namespace Version1.Controllers
{
    public class MoveShapeController
    {
        private Shape _movedShape;
        private bool _isSprint;
        private List<Vector2Int> _nextPositionsShape;
        private float _lastTime;
        private float _time;
        private float _deltaTime = 1;
        private bool _isCanMoved;
        private GameFieldController _gameFieldController;
        public event Action OnShapeStay;
        private IInput _input;
        public MoveShapeController(GameFieldController gameFieldController, IInput input)
        {
            _input = input;
            _time = 0;
            _input.ReturnButtonEvent += OnButtonChange;
            _gameFieldController = gameFieldController;
            _nextPositionsShape = new List<Vector2Int>();
            _isCanMoved = true;
        }

        public void DevideDeltaTime()
        {
            _deltaTime *= 0.5f;
        }
        private void OnButtonChange(Button button, ButtonState buttonstate)
        {
            switch (button)
            {
                case Button.Right:
                    if (!TryMoveTo(Vector2Int.Right)) return;
                    UpdateMatrix();
                    break;
                case Button.Left:
                    if (!TryMoveTo(Vector2Int.Left)) return;
                    UpdateMatrix();
                    break;
                case Button.Up:
                    if(!TryRotate()) return;
                    UpdateMatrix();
                    break;
                case Button.Down:
                    _isSprint = buttonstate == ButtonState.OnPressed;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(button), button, null);
            }
        }

        public bool TryRotate()
        {
            for (var i = 0; i < _movedShape.Points.Count; i++)
            {
                var deltaPosition = _movedShape.Points[i] - _movedShape.CenterPosition;
                _nextPositionsShape[i] = _movedShape.CenterPosition + new Vector2Int(-deltaPosition.Y, deltaPosition.X);
                if (!CheckRange(_nextPositionsShape[i]) || _gameFieldController.CheckPointValue(_nextPositionsShape[i], PointStatus.Stay))
                {
                    return false;
                }
            }
            return true;
        }
        public void ChangeShape(Shape shape)
        {
            _lastTime = Time.time;
            _time = Time.time;
            _isCanMoved = true;
            _movedShape = shape;
            _nextPositionsShape.Clear();
            _nextPositionsShape.AddRange(shape.Points);
        }

        public void Fixed()
        {
            MoveDown();
        }

        public void MoveDown()
        {
            if(!_isCanMoved) return;
            _time += Time.deltaTime;
            if (!(_time - _lastTime > _deltaTime*(_isSprint? 0.1f:1))) return;
            _lastTime = _time;
            if (!TryMoveTo(Vector2Int.Up))
            {
                _isCanMoved = false;
                OnShapeStay?.Invoke();
                return;
            }

            UpdateMatrix();
        }
        List<(Vector2Int startPoint, Vector2Int endPoint)> GetPoinsAndNextPoints() => _movedShape.Points.Zip(_nextPositionsShape,
            (startPosition, endPosition) => (startPosition, endPosition)).ToList();

        public void UpdateMatrix()
        {
            _gameFieldController.MovePoints(GetPoinsAndNextPoints());
            _movedShape.UpdatePointPosition(_nextPositionsShape);
        }
        public bool TryMoveTo(Vector2Int direction)
        {
            for (var i = 0; i < _movedShape.Points.Count; i++)
            {
                _nextPositionsShape[i] = _movedShape.Points[i] + direction;
                if (!CheckRange(_nextPositionsShape[i]) || _gameFieldController.CheckPointValue(_nextPositionsShape[i], 2))
                {
                    return false;
                }
            }
            return true;
        }

        public void OnDisable()
        {
            _input.ReturnButtonEvent -= OnButtonChange;
        }
        public bool CheckRange(Vector2Int position) =>position.Y >= 0 && position.Y < _gameFieldController.Size.Y && position.X >= 0 && position.X < _gameFieldController.Size.X;
    }
}
