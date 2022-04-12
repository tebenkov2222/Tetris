namespace Version1.Controllers
{
    public class MatrixOperationsController
    {
        private GameFieldController _gameFieldController;

        public MatrixOperationsController(GameFieldController gameFieldController)
        {
            _gameFieldController = gameFieldController;
        }
        public bool CheckRow(int rowCheck)
        {
            for (int i = 0; i < _gameFieldController.Size.X; i++)
            {
                if (_gameFieldController.CheckPointValue(new Vector2Int(i, rowCheck), 0)) return false;
            }

            return true;
        }

        public void ClearRow(int rowCheck)
        {
            for (int j = 0; j < _gameFieldController.Size.X; j++)
            {
                _gameFieldController.DeletePoint(new Vector2Int(j, rowCheck));
            }
        }
        public void MoveDownAllUnder(int rowCheck)
        {
            for (int i = rowCheck; i > 0; i--)
            {
                for (int j = 0; j < _gameFieldController.Size.X; j++)
                {
                    _gameFieldController.MovePoint(new Vector2Int(j, i-1), new Vector2Int(j, i));
                }
            }
        }
    }
}
