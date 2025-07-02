using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUpQuitView : View
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    public override void Initialize()
    {
        _yesButton.onClick.AddListener(() => Application.Quit());
        _noButton.onClick.AddListener(() => ViewManager.ShowLast());
    }
}
