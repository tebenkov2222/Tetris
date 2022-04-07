
using UnityEngine;

namespace Version1.Controllers
{
    public class MatrixOperationsController
    {
        private MatrixController _matrixController;

        public MatrixOperationsController(MatrixController matrixController)
        {
            _matrixController = matrixController;
        }
        public bool CheckRow(int rowCheck) => !_matrixController.Matrix[rowCheck].Contains(0);
        public void ClearRow(int rowCheck)
        {
            for (int j = 0; j < _matrixController.Size.X; j++)
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
                for (int j = 0; j < _matrixController.Size.X; j++)
                {
                    _matrixController.MovePoint(new Vector2Int(j, i-1), new Vector2Int(j, i));
                }
            }
        }
    }
}
