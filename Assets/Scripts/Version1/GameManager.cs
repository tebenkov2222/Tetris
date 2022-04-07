using System;
using System.Collections.Generic;
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
        [SerializeField] private ScoreView _scoreView; 
        [SerializeField] private ScoreView _maxScoreView; 
        [SerializeField] private MatrixControllerDto _matrixControllerDto;
        [SerializeField] private InputPcSo _pcSettings;
        private bool _isEndGame;

        private Shape _movedShape;
        private Shape _nextShape;
        
        private IInput _input;

        private MatrixController _matrixController;
        private MatrixOperationsController _matrixOperationsController;
        private MoveShapeController _moveShape;
        private SpawnShapeController _spawnShapeController;
        private CheckRoundsController _checkRoundsController;
        private LevelUpController _levelUpController;
        private ScoreController _scoreController;
        private Score _score;
        
        private void Awake()
        {
            _input = new PCInput(_pcSettings);
            _matrixController = new MatrixController(_matrixControllerDto);
            _matrixOperationsController = new MatrixOperationsController(_matrixController, _matrixControllerDto.Size);
            _checkRoundsController = new CheckRoundsController(_matrixOperationsController);
            _moveShape = new MoveShapeController(_matrixController,_input);
            _scoreController = new ScoreController();
            _scoreController.Score.OnValueChange += _scoreView.SetValue;
            _scoreController.MaxScore.OnValueChange += _maxScoreView.SetValue;
            _maxScoreView.SetValue(_scoreController.MaxScore.Value);
            _moveShape.OnShapeStay+=OnShapeStay;
            _spawnShapeController = new SpawnShapeController(_matrixControllerDto.Prefab);
            _spawnShapeController.OnSpawnShape+=OnSpawnShape;
            _spawnShapeController.OnFullMatrix+=OnFullMatrix;
            _spawnShapeController.SpawnRandomShape();
            _levelUpController = new LevelUpController(_moveShape);
        }

        private void OnFullMatrix()
        {
            _isEndGame = true;
        }

        private void OnShapeStay()
        {
            if(_isEndGame) return;
            _matrixController.StayShape(_movedShape.Points);
            var check = _checkRoundsController.Check(_movedShape.GetRows());
            _scoreController.AddScoreByLine(check);
            _spawnShapeController.SpawnRandomShape();
        }

        private void OnDisable()
        {
            _spawnShapeController.OnSpawnShape-=OnSpawnShape;
            _moveShape.OnShapeStay-=OnShapeStay;
            _scoreController.Score.OnValueChange -= _scoreView.SetValue;
            _scoreController.MaxScore.OnValueChange -= _maxScoreView.SetValue;
        }

        private void OnSpawnShape(Shape spawnedShape)
        {
            foreach (var point in spawnedShape.Points)
            {
                if (_matrixController.CheckMatrixValue(point, 2))
                {
                    FullMatrix();
                    return;
                }
            }
            
            if(_isEndGame) return;
            _movedShape = spawnedShape;
            _moveShape.ChangeShape(spawnedShape);
            _matrixController.SpawnPoints(spawnedShape.PointViews, spawnedShape.Points);
        }

        private void FullMatrix()
        {
            
        }
        private void FixedUpdate()
        {
            if(_isEndGame) return;
            _moveShape.Fixed();
        }

        private void Update()
        {
            _input.UpdateInput();
            if(_isEndGame) return;
            _levelUpController.Update();
        }
    }
}
