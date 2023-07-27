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
        SceneManager.LoadScene(SceneToLoad);
    }
}