using UnityEngine;
using Version1.Core;
using Version1.Shared;

namespace Version1.Controllers
{
    public class LevelUpController
    {
        private float _lastTime;
        private float _deltaTime = 60;
        private int savedValue = 0;
        public event ReturnVoid OnLevelUp;
        public LevelUpController(Score score)
        {
            score.OnValueChange+=ScoreOnValueChanged;
            _lastTime = Time.time;
        }

        private void ScoreOnValueChanged(int value)
        {
            int floorToInt = Mathf.FloorToInt(value/1000);
            if (floorToInt > savedValue)
            {
                savedValue = floorToInt;
                OnLevelUp?.Invoke();
            }
        }

        public void UpdateTime()
        {
            _lastTime = Time.time;
        }
        public void Update()
        {
            if (Time.time - _lastTime > _deltaTime)
            {
                _lastTime = Time.time;
            }
        }
    }
}
