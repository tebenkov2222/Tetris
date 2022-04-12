using UnityEngine;
using Random = UnityEngine.Random;

public class CheckButtonController
{
    private CheckButtonView _checkButtonView;
    public CheckButtonController(CheckButtonView checkButtonView)
    {
        _checkButtonView = checkButtonView;
    }

    private bool _isValue;

    public void Update()
    {
        _checkButtonView.UpdateText(Random.Range(-1,1).ToString());
        _checkButtonView.UpdateText1($"Delta Time {Time.deltaTime}");
        _checkButtonView.UpdateText2("Time" + Time.time);
        _checkButtonView.UpdateText3("value = " + (_isValue ? "1" : "0"));
        _checkButtonView.UpdateText4("Static text");
    }
}
