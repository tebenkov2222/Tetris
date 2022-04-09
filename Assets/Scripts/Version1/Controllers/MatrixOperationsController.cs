namespace Version1.Controllers
{
    public class MatrixOperationsController
    {
        private GameController _gameController;

        public MatrixOperationsController(GameController gameController)
        {
            _gameController = gameController;
        }
        public bool CheckRow(int rowCheck) => !_gameController.Matrix[rowCheck].Contains(0);
        public void ClearRow(int rowCheck)
        {
            for (int j = 0; j < _gameController.Size.X; j++)
            {
                _gameController.DeletePoint(new Vector2Int(j, rowCheck));
            }
        }
        public void MoveDownAllUnder(int rowCheck)
        {
            for (int i = rowCheck; i > 0; i--)
            {
                for (int j = 0; j < _gameController.Size.X; j++)
                {
                    _gameController.MovePoint(new Vector2Int(j, i-1), new Vector2Int(j, i));
                }
            }
        }
    }
}
