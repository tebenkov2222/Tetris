using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Version2.Field;
using Version2.Shape;
using Version2.View;

namespace Version2
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PointView _prefabPoint;
        [SerializeField] private float _startX, _startY, _deltaX, _deltaY;
        private Beaker _beaker;
        private MatrixController _matrix;
        private MoveShape _moveShape;
        private void Start()
        {
            _beaker = new Beaker();
            _beaker.InstShape();
            //_beaker.Visualisation();
            _matrix = new MatrixController(_prefabPoint, _beaker.Field.Count, _beaker.Field[0].Count, _startX, _startY,
                _deltaX, _deltaY);
            _moveShape = new MoveShape(_beaker);
            _matrix.SetCurrentColor(_beaker.Shape.Color);
        }

        private void Update()
        {
            _moveShape.Move();
            _matrix.UpdateMatrix(_beaker.Field);
        }
    }
}