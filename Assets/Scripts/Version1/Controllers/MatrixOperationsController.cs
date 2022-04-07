
using UnityEngine;

namespace Version1.Controllers
{
    public class MatrixOperationsController
    {
        private MatrixController _matrixController;
        private Vector2Int _size;

        public MatrixOperationsController(MatrixController matrixController, Vector2Int size)
        {
            _matrixController = matrixController;
            _size = size;
        }
        public bool CheckRow(int rowCheck) => !_matrixController.Matrix[rowCheck].Contains(0);
        public void ClearRow(int rowCheck)
        {
            for (int j = 0; j < _size.X; j++)
            {
                _matrixController.SetMatrixValue(new Vector2Int(j,rowCheck),0);
                Object.Destroy(_matrixController.GetMatrixViewValue(new Vector2Int(j,rowCheck)).gameObject);
                _matrixController.SetMatrixViewValue(new Vector2Int(j,rowCheck),null);
            }
        }
        public void MoveDownAllUnder(int rowCheck)
        {
            for (int i = rowCheck; i > 0; i--)
            {
                for (int j = 0; j < _size.X; j++)
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
