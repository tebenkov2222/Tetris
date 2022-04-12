using UnityEngine;
using UnityEngine.UI;

public class CheckButtonView : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Text _text1;
    [SerializeField] private Text _text2;
    [SerializeField] private Text _text3;
    [SerializeField] private Text _text4;

    public void UpdateText(string value)
    {
        _text.text = value;
    }
    public void UpdateText1(string value)
    {
        _text1.text = value;
    }
    public void UpdateText2(string value)
    {
        _text2.text = value;
    }
    public void UpdateText3(string value)
    {
        _text3.text = value;
    }
    public void UpdateText4(string value)
    {
        _text4.text = value;
    }
}



