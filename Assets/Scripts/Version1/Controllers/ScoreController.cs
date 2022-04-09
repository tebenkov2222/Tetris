
using UnityEngine;
using Version1.Core;

namespace Version1.Controllers
{
    public class ScoreController
    {
        private Score _score;
        private Score _maxScore;

        public Score Score => _score;

        public Score MaxScore => _maxScore;
        private void AddScore(int scoreValue)
        {
            _score.AddScore(scoreValue);
            if (_maxScore.Value < _score.Value)
            {
                _maxScore.Value = _score.Value;
                PlayerPrefs.SetInt("MaxScore", _score.Value);
                PlayerPrefs.Save();

            }
        }
        public ScoreController()
        {
            _score = new Score();
            var maxScorevalue = 0;
            if (PlayerPrefs.HasKey("MaxScore"))
            {
                maxScorevalue = PlayerPrefs.GetInt("MaxScore");
            }
            else PlayerPrefs.SetInt("MaxScore", 0);

            _maxScore = new Score(maxScorevalue);
        }
        public void AddScoreByLine(int count)
        {
            switch (count)
            {
                case 1: AddScore(100); break;
                case 2: AddScore(300); break;
                case 3: AddScore(700); break;
                case 4: AddScore(1500); break;
            }
        }
    }
}
