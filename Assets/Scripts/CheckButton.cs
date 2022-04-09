using System;
using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Text _text;
    private int _count;
    private void Start()
    {
        _button.onClick.AddListener(ButtonOnClick);
    }

    private void ButtonOnClick()
    {
        _count++;
        _text.text = _count.ToString();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ButtonOnClick);
    }
}


