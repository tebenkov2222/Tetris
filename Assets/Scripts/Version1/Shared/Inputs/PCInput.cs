using App.Scripts.Shared.Inputs.Other;
using App.Scripts.Shared.Inputs.ScriptableObjects;
using UnityEngine;

namespace App.Scripts.Shared.Inputs
{
    public class PCInput : IInput
    {
        private InputPcSo _pcSettings;
        public PCInput(InputPcSo pcSettings)
        {
            _pcSettings = pcSettings;
        }
        public event ReturnInputButtonAndState ReturnButtonEvent;
        public event ReturnInputAxis ReturnAxisEvent;
        public void UpdateInput()
        {
            CheckMovementAxis();
            CheckButtons();
        }
        private void CheckButtons()
        {
            CheckButton(_pcSettings.DownBtn, Button.Down, new[] {ButtonState.OnPressed, ButtonState.OnUp});
            CheckButton(_pcSettings.LeftBtn, Button.Left, new[] {ButtonState.OnDown});
            CheckButton(_pcSettings.RightBtn, Button.Right, new[] {ButtonState.OnDown});
            CheckButton(_pcSettings.UpBtn, Button.Up, new[] {ButtonState.OnDown});
        }

        private void CheckButton(KeyCode code,Button button, ButtonState []states)
        {
            foreach (ButtonState state in states)
            {
                switch (state)
                {
                    case ButtonState.OnDown:
                        if (Input.GetKeyDown(code))   ReturnButtonEvent?.Invoke(button, ButtonState.OnDown);
                        break;
                    case ButtonState.OnPressed:
                        if (Input.GetKey(code))   ReturnButtonEvent?.Invoke(button, ButtonState.OnPressed);
                        break;
                    case ButtonState.OnUp:
                        if (Input.GetKeyUp(code))   ReturnButtonEvent?.Invoke(button, ButtonState.OnUp);
                        break;
                }
            }
        }
        private void CheckMovementAxis()
        {
            
        }
    }
}
