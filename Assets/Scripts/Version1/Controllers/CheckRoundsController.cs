using System.Collections.Generic;
using Version1.Shared;

namespace Version1.Controllers
{
    public class CheckRoundsController
    {
        private MatrixOperationsController _matrixOperationsController;
        private int _countCHeck = 0;
        public CheckRoundsController(MatrixOperationsController matrixOperationsController)
        {
            _matrixOperationsController = matrixOperationsController;
        }
        public int Check(List<int> rows)
        {
            _countCHeck = 0;
            foreach (var i in rows)
            {
                while (_matrixOperationsController.CheckRow(i))
                {
                    _countCHeck++;
                    _matrixOperationsController.ClearRow(i);
                    _matrixOperationsController.MoveDownAllUnder(i);
                }
            }
            return _countCHeck;
        }
    }
}
