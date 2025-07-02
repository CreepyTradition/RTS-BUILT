using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad = "PlayScene";   // ← your actual game scene
    [SerializeField] private float _minShowTime = 1f;             // seconds to hold the splash

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        float start = Time.time;

        var op = SceneManager.LoadSceneAsync(_sceneToLoad);
        op.allowSceneActivation = false;

        // wait until Unity reports 90% (it reserves 10% for the activation step)
        while (op.progress < 0.9f)
            yield return null;

        // enforce minimum display time
        float elapsed = Time.time - start;
        if (elapsed < _minShowTime)
            yield return new WaitForSeconds(_minShowTime - elapsed);

        // flip to the real scene
        op.allowSceneActivation = true;
    }
}
