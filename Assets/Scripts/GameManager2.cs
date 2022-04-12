using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    [SerializeField] private CheckButtonView _checkButtonView;
    private CheckButtonController _checkButtonController;

    private void Awake()
    {
        _checkButtonController = new CheckButtonController(_checkButtonView);
    }

    private void Update()
    {
        _checkButtonController.Update();
    }
}
