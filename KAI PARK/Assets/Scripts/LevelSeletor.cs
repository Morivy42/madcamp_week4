using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string SceneToLoad;

    // Update is called once per frame
   
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     SelectLevel();
        // }
    }   

    public void SelectLevel(string SceneToLoad)
    {
        Debug.Log(SceneToLoad);
        // last character of SceneToLoad is the stage number
        PlayerPrefs.SetInt("Level", SceneToLoad[SceneToLoad.Length - 1] - '0');
        // SceneManager.LoadScene(SceneToLoad);
        Debug.Log("SceneToLoad: " + SceneToLoad);
        LoadingSceneManager.LoadScene(SceneToLoad);
    }
}