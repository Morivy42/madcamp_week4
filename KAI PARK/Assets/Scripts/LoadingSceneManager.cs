using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        Debug.Log("LoadingScene: " + nextScene);
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(nextScene);
        asyncOp.allowSceneActivation = false;

        float timer = 0.0f;
        while (!asyncOp.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            // if (asyncOp.progress >= 0.9f)
            // {
            //     asyncOp.allowSceneActivation = true;
            // }

            if (timer > 1.0f)
            {
                asyncOp.allowSceneActivation = true;
            }

        }
    }
}
