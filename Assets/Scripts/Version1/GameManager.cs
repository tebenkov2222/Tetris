using System;
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
        private void Awake()
        {
            _input = new PCInput(_pcSettings);
            _matrixController = new MatrixController(_matrixControllerDto);
            _moveShape = new MoveShapeController(_matrixController,_input, _matrixControllerDto.SizeX, _matrixControllerDto.SizeY);
            _moveShape.OnShapeStay+=OnShapeStay;
            _spawnShapeController = new SpawnShapeController(_matrixController, _matrixControllerDto);
            _spawnShapeController.OnSpawnShape+=OnSpawnShape;
            _spawnShapeController.SpawnRandomShape();
        }

        private void OnShapeStay()
        {
            _spawnShapeController.SpawnRandomShape();
        }

        private void OnDisable()
        {
            _spawnShapeController.OnSpawnShape-=OnSpawnShape;
            _moveShape.OnShapeStay-=OnShapeStay;
        }

        private void OnSpawnShape(Shape shape)
        {
            _moveShape.ChangeShape(_spawnShapeController.Positions);
        }

        private void FixedUpdate()
        {
            _moveShape.Fixed();
        }

        private void Update()
        {
            _input.UpdateInput();

        }
    }
}
