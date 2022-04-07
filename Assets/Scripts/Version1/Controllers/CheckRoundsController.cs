using System.Collections.Generic;

namespace Version1.Controllers
{
    public class CheckRoundsController
    {
        private MatrixOperationsController _matrixOperationsController;
        private int _countCheck;
        public CheckRoundsController(MatrixOperationsController matrixOperationsController)
        {
            _matrixOperationsController = matrixOperationsController;
        }
        public int Check(List<int> rows)
        {
            _countCheck = 0;
            foreach (var i in rows)
            {
                while (_matrixOperationsController.CheckRow(i))
                {
                    _countCheck++;
                    _matrixOperationsController.ClearRow(i);
                    _matrixOperationsController.MoveDownAllUnder(i);
                }
            }
            return _countCheck;
        }
    }
}
