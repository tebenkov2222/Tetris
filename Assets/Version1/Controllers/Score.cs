
using Version1.Shared;

namespace Version1.Controllers
{
    public class Score
    {
        public event ReturnInt OnValueChange;
        private int _value;

        public int Value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
                    OnValueChange?.Invoke(_value);
                }
            }
        }

        public void AddScore(int value)
        {
            Value += value;
        }

        public Score()
        {
            _value = 0;
        }

        public Score(int startValue)
        {
            _value = startValue;
        }
    }
}
