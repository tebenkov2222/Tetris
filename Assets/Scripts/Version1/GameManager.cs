using App.Scripts.Shared.Inputs;
using UnityEngine;
using Version1.Controllers;
using Version1.Shared.Inputs;
using Version1.Shared.Inputs.ScriptableObjects;
using Version1.UI;
using Version1.Views;

namespace Version1
{
    public class GameManager : MonoBehaviour
    { 
        [SerializeField] private GameControllerView _gameControllerView;
        [SerializeField] private StartWindowView _startWindowView;
        [SerializeField] private GameWindowView _gameWindowView;
        [SerializeField] private InputPcSo _pcSettings;

        private GameController _gameController;
        private IInput _input;
        private bool _isActiveGame = false;


        
        private void Awake()
        {
            _input = new PCInput(_pcSettings);
            _gameController = new GameController(_gameControllerView, _input);

            _startWindowView.OnStart+=StartGame;
        }

        private void StartGame()
        {
            _startWindowView.Hide();
            _gameController.StartGame();
            _isActiveGame = true;
        }
        

        private void Update()
        {
            _input.UpdateInput();
            
            if(!_isActiveGame) return;
            _gameController.Update();
        }
        

        private void OnDisable()
        {
            _gameController.OnDisable();
        }

    }
}
