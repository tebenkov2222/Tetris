using System.Linq;
using App.Scripts.Shared.Inputs;
using App.Scripts.Shared.Inputs.ScriptableObjects;
using UnityEngine;
using Version1.Controllers;
using Version1.Core;
using Version1.DTOs;
using Version1.Views;

namespace Version1
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PointView _pointViewPrefab;
        [SerializeField] private ScoreView _scoreView; 
        [SerializeField] private ScoreView _maxScoreView; 
        [SerializeField] private MatrixControllerDto _matrixControllerDto;
        [SerializeField] private WindowControllerDto _windowControllerDto;
        [SerializeField] private InputPcSo _pcSettings;
        private bool _isEndGame;

        private Shape _movedShape;
        private Shape _nextShape;
        
        private IInput _input;

        private MatrixController _matrixController;
        private MatrixOperationsController _matrixOperationsController;
        private MoveShapeController _moveShapeController;
        private SpawnShapeController _spawnShapeController;
        private CheckRoundsController _checkRoundsController;
        private LevelUpController _levelUpController;
        private ScoreController _scoreController;
        private Score _score;
        private WindowController _windowController;

        private bool _windowSerialized;
        
        private void Awake()
        {
            _input = new PCInput(_pcSettings);
            
            _scoreController = new ScoreController();
            _scoreController.Score.OnValueChange += _scoreView.SetValue;
            _scoreController.MaxScore.OnValueChange += _maxScoreView.SetValue;
            _maxScoreView.SetValue(_scoreController.MaxScore.Value);

            _matrixController = new MatrixController(_matrixControllerDto);
            _matrixOperationsController = new MatrixOperationsController(_matrixController);
            _checkRoundsController = new CheckRoundsController(_matrixOperationsController);

            _windowController = new WindowController(_windowControllerDto);

            _moveShapeController = new MoveShapeController(_matrixController,_input);
            _moveShapeController.OnShapeStay+=OnShapeControllerStay;
            _spawnShapeController = new SpawnShapeController(_pointViewPrefab);
            _levelUpController = new LevelUpController(_moveShapeController);
            SpawnShape();
        }

        private void OnShapeControllerStay()
        {
            if(_isEndGame) return;
            _matrixController.StayShape(_movedShape.Points);
            var check = _checkRoundsController.Check(_movedShape.GetRows());
            _scoreController.AddScoreByLine(check);
            SpawnShape();
        }

        private void OnDisable()
        {
            _moveShapeController.OnDisable();
            _moveShapeController.OnShapeStay-=OnShapeControllerStay;
            _scoreController.Score.OnValueChange -= _scoreView.SetValue;
            _scoreController.MaxScore.OnValueChange -= _maxScoreView.SetValue;
        }

        private void SpawnShape()
        {
            if (!_windowSerialized)
            {
                _windowSerialized = true;
                _nextShape = _spawnShapeController.SpawnRandomShape();
            }

            _movedShape = _nextShape;

            if (_movedShape.Points.Any(point => _matrixController.CheckMatrixValue(point, 2)))
            {
                FullMatrix();
                return;
            }

            if(_isEndGame) return;
            
            Shape randomShape = _spawnShapeController.SpawnRandomShape();
            _nextShape = randomShape;
            _windowController.UpdateShape(randomShape);

            _moveShapeController.ChangeShape(_movedShape);
            _matrixController.SpawnPoints(_movedShape.PointViews, _movedShape.Points);
        }

        private void FullMatrix()
        {
            _isEndGame = true;
        }
        private void FixedUpdate()
        {
            if(_isEndGame) return;
            _moveShapeController.Fixed();
        }

        private void Update()
        {
            _input.UpdateInput();
            if(_isEndGame) return;
            _levelUpController.Update();
        }
    }
}
