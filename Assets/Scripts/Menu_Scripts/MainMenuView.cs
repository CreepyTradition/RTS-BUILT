using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _quitButton;

    public override void Initialize()
    {
        _startButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        _creditsButton.onClick.AddListener(() => ViewManager.Show<CreditsMenuView>());
        _quitButton.onClick.AddListener(() => ViewManager.Show<PopUpQuitView>());

    }
}
