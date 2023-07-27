using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class EscapeMenu : MonoBehaviour
{
    public GameObject whiteCanvas;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void LeaveGame(){
        EventSystem.current.SetSelectedGameObject(null);
        SceneManager.LoadScene("LevelSelect");

    }  

    public void ReturnGame(){
        EventSystem.current.SetSelectedGameObject(null);
        Time.timeScale = 1f;
        whiteCanvas.SetActive(false);
        gameObject.SetActive(false);
    }

    public void RestartGame(){
        EventSystem.current.SetSelectedGameObject(null);
        Time.timeScale = 1f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
