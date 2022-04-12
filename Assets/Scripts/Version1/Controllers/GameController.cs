using System.Linq;
using App.Scripts.Shared.Inputs;
using Version1.Core;
using Version1.Views;

namespace Version1.Controllers
{
    public class GameController
    {
        private GameFieldController _beakerField;
        private GameFieldController _windowField;
        private MatrixOperationsController _matrixOperationsController;
        private CheckRoundsController _checkRoundsController;
        private MoveShapeController _moveShapeController;
        private SpawnShapeController _spawnShapeController;
        private LevelUpController _levelUpController;
        private ScoreController _scoreController;
        private Shape _movedShape;
        private Shape _nextShape;
        
        private ScoreView _scoreView; 
        private ScoreView _maxScoreView; 
        
        private bool _isEndGame;
        private bool _windowSerialized;

        public GameController(GameControllerView gameControllerView, IInput input)
        {
            _scoreView = gameControllerView.ScoreView;
            _maxScoreView = gameControllerView.MaxScoreView;
            gameControllerView.BeakerView.Init();
            gameControllerView.WindowView.Init();
            _beakerField = new GameFieldController(gameControllerView.BeakerView);
            _windowField = new GameFieldController(gameControllerView.WindowView);
            
            _matrixOperationsController = new MatrixOperationsController(_beakerField);
            _checkRoundsController = new CheckRoundsController(_matrixOperationsController);
            _scoreController = new ScoreController();
            _scoreController.Score.OnValueChange += _scoreView.SetValue;
            _scoreController.MaxScore.OnValueChange += _maxScoreView.SetValue;
            
            _maxScoreView.SetValue(_scoreController.MaxScore.Value);
            _moveShapeController = new MoveShapeController(_beakerField,input);
            _moveShapeController.OnShapeStay+=OnShapeControllerStay;
            _spawnShapeController = new SpawnShapeController();
            _levelUpController = new LevelUpController(_scoreController.Score);
            _levelUpController.OnLevelUp+=LevelUp;
        }

        private void LevelUp()
        {
            _moveShapeController.DevideDeltaTime();
        }

        public void StartGame()
        {
            _isEndGame = false;
            _levelUpController.UpdateTime();
            SpawnShape();

        }
        public void ClearGame()
        {
            
        }
        private void OnShapeControllerStay()
        {
            if(_isEndGame) return;
            foreach (var point in _movedShape.Points)
            {
                _beakerField.SetPointValue(point, PointStatus.Stay);
            }
            var check = _checkRoundsController.Check(_movedShape.GetRows()); 
            _scoreController.AddScoreByLine(check); // проверка сорке
            SpawnShape(); // спавн. новую фигуру
        }
        private void SpawnShape()
        {
            if (!_windowSerialized)
            {
                _windowSerialized = true;
                _nextShape = _spawnShapeController.SpawnRandomShape();
            }

            _movedShape = _nextShape;
            
            Shape randomShape = _spawnShapeController.SpawnRandomShape();
            _windowField.DeletePoints(_nextShape.Points);
            _nextShape = randomShape;
            _windowField.SpawnPoints(randomShape.Points, randomShape.Color);

            _movedShape.UpdatePointPosition(_movedShape.Points.Select(t => t + new Vector2Int(3, 0)).ToList());

            if (_movedShape.Points.Any(point => _beakerField.CheckPointValue(point, 2)))
            {
                FullMatrix();
                return;
            }

            if(_isEndGame) return;


            _moveShapeController.ChangeShape(_movedShape);
            _beakerField.SpawnPoints(_movedShape.Points, _movedShape.Color);
        }
        private void FullMatrix()
        {
            _isEndGame = true;
        }

        public void Update()
        {
            if(_isEndGame) return;
            _levelUpController.Update();
            _moveShapeController.Fixed();
        }
        public void OnDisable()
        {
            _moveShapeController.OnDisable();
            _moveShapeController.OnShapeStay-=OnShapeControllerStay;
            _scoreController.Score.OnValueChange -= _scoreView.SetValue;
            _scoreController.MaxScore.OnValueChange -= _maxScoreView.SetValue;
            _levelUpController.OnLevelUp-=LevelUp;
        }
    }
}