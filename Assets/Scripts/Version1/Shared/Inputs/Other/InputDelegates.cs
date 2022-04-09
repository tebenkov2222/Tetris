using App.Scripts.Shared.Inputs;
using UnityEngine;

namespace Version1.Shared.Inputs.Other
{
    public delegate void ReturnInputButtonAndState(Button button, ButtonState buttonState);
    public delegate void ReturnInputAxis(Axis axis, Vector2 value);
}
