using System.Collections.Generic;
using UnityEngine;
using Version1.Views;

namespace Version1.Controllers
{
    public class CheckRoundsController
    {
        private MatrixController _matrixController;
        private int _sizeX;
        private int _sizeY;
        public CheckRoundsController(MatrixController matrixController, int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _matrixController = matrixController;
        }
        public void Check(List<Vector2Int> pointViews)
        {
            List<int> rowsCheck = new List<int>();
            foreach (var pointView in pointViews)
            {
                if(!rowsCheck.Contains(pointView.Y)) rowsCheck.Add(pointView.Y); 
            }
            foreach (var i in rowsCheck)
            {
                if (CheckRow(i))
                {
                    ClearRow(i);
                    MoveDownAllUnder(i);
                }
            }
        }

        private bool CheckRow(int rowCheck) => !_matrixController.Matrix[rowCheck].Contains(0);
        private void ClearRow(int rowCheck)
        {
            for (int j = 0; j < _sizeX; j++)
            {
                _matrixController.SetMatrixValue(new Vector2Int(j,rowCheck),0);
                Object.Destroy(_matrixController.GetMatrixViewValue(new Vector2Int(j,rowCheck)).gameObject);
                _matrixController.SetMatrixViewValue(new Vector2Int(j,rowCheck),null);
            }
        }
        private void MoveDownAllUnder(int rowCheck)
        {
            for (int i = rowCheck; i > 0; i--)
            {
                for (int j = 0; j < _sizeX; j++)
                {
                    _matrixController.MovePoint(new Vector2Int(j, i-1), new Vector2Int(j, i));
                }
            }
            if (CheckRow(rowCheck))
            {
                ClearRow(rowCheck);
                MoveDownAllUnder(rowCheck);
            }
        }
    }
}
