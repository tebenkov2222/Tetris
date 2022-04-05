using App.Scripts.Shared.Inputs.Other;
using UnityEngine;

namespace App.Scripts.Shared.Inputs
{
    public interface IInput
    {
        public event ReturnInputButtonAndState ReturnButtonEvent;
        public event ReturnInputAxis ReturnAxisEvent;
        public void UpdateInput();
    }
    public class InputDecorator: IInput
    {
        private IInput _input;
        private IInput _inputNext;
        public event ReturnInputButtonAndState ReturnButtonEvent;
        public event ReturnInputAxis ReturnAxisEvent;

        public InputDecorator(IInput input)
        {
            _input = input;
            _input.ReturnButtonEvent += InputOnReturnButton;
            _input.ReturnAxisEvent += InputOnReturnAxis;
        }

        

        public InputDecorator(IInput input, IInput inputNext)
        {
            _input = input;
            _inputNext = inputNext;
            _input.ReturnButtonEvent += InputOnReturnButton;
            _input.ReturnAxisEvent += InputOnReturnAxis;
            inputNext.ReturnButtonEvent += InputOnReturnButton;
            inputNext.ReturnAxisEvent += InputOnReturnAxis;
        }
        private void InputOnReturnAxis(Axis axis, Vector2 value) => ReturnAxisEvent?.Invoke(axis, value);
        private void InputOnReturnButton(Button button, ButtonState buttonState) => ReturnButtonEvent?.Invoke(button, buttonState);
        
        public void UpdateInput()
        {
            _input.UpdateInput();
            _inputNext?.UpdateInput();
        }
    }

    public enum Button
    {
        Left,
        Right,
        Up,
        Down
    }
    public enum ButtonState
    {
        OnDown,
        OnPressed,
        OnUp
    }
    public enum Axis
    {
        Movement,
        Rotate
    }

    public enum InputType
    {
        Mobile,
        PC
    }
}
