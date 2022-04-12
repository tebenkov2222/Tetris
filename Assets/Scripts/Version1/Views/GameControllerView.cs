using App.Scripts.Shared.Inputs;
using UnityEngine;
using Version1.Shared.Inputs.ScriptableObjects;

namespace Version1.Views
{
    public class GameControllerView : MonoBehaviour
    {
        [SerializeField] private ScoreView _scoreView; 
        [SerializeField] private ScoreView _maxScoreView; 
        [SerializeField] private GameFieldView _beakerView; 
        [SerializeField] private GameFieldView _windowView; 

        public ScoreView ScoreView => _scoreView;

        public ScoreView MaxScoreView => _maxScoreView;

        public GameFieldView BeakerView => _beakerView;

        public GameFieldView WindowView => _windowView;
    }
}
