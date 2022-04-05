using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Version2.View;

namespace Version2
{

    public class MatrixController
    {
        private List<List<PointView>> _matrix;

        public List<List<PointView>> Matrix
        {
            get => _matrix;
            private set => _matrix = value;
        }

        private Color _currentColor;
        public MatrixController(PointView prefab, int sizeX, int sizeY, float startX, float startY, float deltaX,
            float deltaY)
        {
            Matrix = new List<List<PointView>>();
            for (int i = 0; i < sizeX; i++)
            {
                Matrix.Add(new List<PointView>());
                for (int j = 0; j < sizeY; j++)
                {
                    PointView instantiate = Object.Instantiate(prefab);
                    Matrix[i].Add(instantiate);
                    instantiate.transform.position = new Vector3(startX + deltaX * j, startY - deltaY * i);
                    instantiate.View(false);
                }
            }
        }

        public void SetCurrentColor(Color currentColor)
        {
            _currentColor = currentColor;
        }
        public void UpdateMatrix(List<List<bool>> values)
        {
            for (var i = 0; i < values.Count; i++)
            {
                for (var y = 0; y < values[y].Count; y++)
                {
                    _matrix[i][y].SetColor(_currentColor);
                    _matrix[i][y].View(values[i][y]);
                    if(values[i][y]) Debug.Log($"{i} {y} is true");
                }
            }
        }
    }
}