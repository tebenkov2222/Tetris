using System.Collections;
using UnityEngine;
using Version2.Field;

namespace Version2.Shape
{
    public class MoveShape
    {
        private Beaker _beaker;
        private IShape _shape => _beaker.Shape;
        private Position _shapePosition => _beaker.Pos;
        private float _lastTime;
        private float _deltaTime = 1f;

        public MoveShape(Beaker beaker)
        {
            _beaker = beaker;
            _lastTime = Time.time;
        }
        public void Move()
        {
            if (Time.time - _lastTime > _deltaTime)
            {
                _beaker.MoveShape(0,1);
                _lastTime = Time.time;
                
            }
        }
    }
}