using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string SceneToLoad;

    // Update is called once per frame
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectLevel();
        }
    }   

    void SelectLevel()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}