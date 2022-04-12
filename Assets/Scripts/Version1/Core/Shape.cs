using System.Collections.Generic;
using UnityEngine;
using Version1.Views;

namespace Version1.Core
{
    public class Shape
    {
        public Color Color => _color;
        private Color _color;
        public List<Vector2Int> Points
        {
            get;
            set;
        }
        public Vector2Int CenterPosition => Points[_centerIndex];
        private int _centerIndex = 0;

        public Shape(List<Vector2Int> points, Color color)
        {
            _color = color;
            Points = new List<Vector2Int>(points);
            FindCenterPoint();
        }

        public List<int> GetRows()
        {
            var rows = new List<int>();
            foreach (var pointView in Points)
            {
                if(!rows.Contains(pointView.Y)) rows.Add(pointView.Y); 
            }

            return rows;
        }
        public List<int> GetColumns()
        {
            var columns = new List<int>();
            foreach (var pointView in Points)
            {
                if(!columns.Contains(pointView.X)) columns.Add(pointView.X); 
            }

            return columns;
        }
        public void UpdatePointPosition(List<Vector2Int> positions)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = positions[i];
            }
        }
        public void FindCenterPoint()
        {
            var centerPosition = new Vector2Int(0, 0);
            foreach (var i in Points)
            {
                centerPosition += i;
            }

            centerPosition /= Points.Count;
            for (var i = 0; i < Points.Count; i++)
            {
                if (Points[i] == centerPosition)
                {
                    _centerIndex = i;
                    return;
                }
            }
        }
    }
}
