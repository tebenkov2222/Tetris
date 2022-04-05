using System;
using System.Collections.Generic;
using App.Scripts.Shared.Inputs;
using App.Scripts.Shared.Inputs.ScriptableObjects;
using UnityEngine;
using Version1.Controllers;
using Version1.DTOs;

namespace Version1
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]private MatrixControllerDto _matrixControllerDto;
        [SerializeField] private InputPcSo _pcSettings;
        private IInput _input;
        private MatrixController _matrixController;
        private MoveShapeController _moveShape;
        private SpawnShapeController _spawnShapeController;
        private CheckRoundsController _checkRoundsController;
        private LevelUpController _levelUpController;
        private bool _isEndGame;
        private void Awake()
        {
            _input = new PCInput(_pcSettings);
            _matrixController = new MatrixController(_matrixControllerDto);
            _checkRoundsController = new CheckRoundsController(_matrixController, _matrixControllerDto.SizeX,
                _matrixControllerDto.SizeY);
            _moveShape = new MoveShapeController(_matrixController,_input, _matrixControllerDto.SizeX, _matrixControllerDto.SizeY);
            _moveShape.OnShapeStay+=OnShapeStay;
            _spawnShapeController = new SpawnShapeController(_matrixController, _matrixControllerDto);
            _spawnShapeController.OnSpawnShape+=OnSpawnShape;
            _spawnShapeController.OnFullMatrix+=OnFullMatrix;
            _spawnShapeController.SpawnRandomShape();
            _levelUpController = new LevelUpController(_moveShape);
        }

        private void OnFullMatrix()
        {
            _isEndGame = true;
        }

        private void OnShapeStay(List<Vector2Int> positions)
        {
            if(_isEndGame) return;
            _checkRoundsController.Check(positions);
            _spawnShapeController.SpawnRandomShape();
        }

        private void OnDisable()
        {
            _spawnShapeController.OnSpawnShape-=OnSpawnShape;
            _moveShape.OnShapeStay-=OnShapeStay;
        }

        private void OnSpawnShape(Shape shape)
        {
            if(_isEndGame) return;
            _moveShape.ChangeShape(_spawnShapeController.Positions);
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
