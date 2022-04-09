using System;
using System.Linq;
using App.Scripts.Shared.Inputs;
using UnityEngine;
using Version1.Controllers;
using Version1.Core;
using Version1.DTOs;
using Version1.Shared;
using Version1.Shared.Inputs;
using Version1.Shared.Inputs.ScriptableObjects;
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

        private GameController _gameController;
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

            _gameController = new GameController(_matrixControllerDto);
            _matrixOperationsController = new MatrixOperationsController(_gameController);
            _checkRoundsController = new CheckRoundsController(_matrixOperationsController);

            _windowController = new WindowController(_windowControllerDto);

            _moveShapeController = new MoveShapeController(_gameController,_input);
            _moveShapeController.OnShapeStay+=OnShapeControllerStay;
            _spawnShapeController = new SpawnShapeController(_pointViewPrefab);
            _levelUpController = new LevelUpController(_moveShapeController);
            SpawnShape();
        }
        private void OnShapeControllerStay()
        {
            if(_isEndGame) return;
            _gameController.StayShape(_movedShape.Points); // фигура ввстала на место (2 становится в матрице)
            var check = _checkRoundsController.Check(_movedShape.GetRows()); 
            _scoreController.AddScoreByLine(check); // проверка сорке
            SpawnShape(); // спавн. новую фигуру
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

            if (_movedShape.Points.Any(point => _gameController.CheckMatrixValue(point, 2)))
            {
                FullMatrix();
                return;
            }

            if(_isEndGame) return;
            
            Shape randomShape = _spawnShapeController.SpawnRandomShape();
            _nextShape = randomShape;
            _windowController.UpdateShape(randomShape);

            _moveShapeController.ChangeShape(_movedShape);
            _gameController.SpawnPoints(_movedShape.PointViews, _movedShape.Points);
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
