using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAdditiveLoader : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(LoadDebugScene());
    }

    IEnumerator LoadDebugScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Printer.SetLoaded();
    }
}
