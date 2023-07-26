using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameObject nupjukBlue;
    public GameObject nupjukPink;
    public GameObject Key;
    private GameObject keyOwner;
    
    // scene 전환을 위한 변수
    [SerializeField] private string sceneName;

    private Renderer blueRenderer;
    private Renderer pinkRenderer;
    private bool isPlayersInactive = false;
    private bool keyTaken = false;
    private float inactiveTimer = 5f; // 5초 카운트 변수

    // Start is called before the first frame update
    void Start()
    {
        blueRenderer = nupjukBlue.GetComponent<Renderer>();
        pinkRenderer = nupjukPink.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        keyTaken = Key.GetComponent<KeyScript>().taken;
        keyOwner = Key.GetComponent<KeyScript>().targetObj;
        if (keyTaken)
        {
            if (pinkRenderer.enabled == false && blueRenderer.enabled == false)
            {
                isPlayersInactive = false;
                SceneManager.LoadScene(sceneName);
            }

            if (isPlayersInactive == false && (pinkRenderer.enabled != blueRenderer.enabled))
            {
                if (keyOwner.GetComponent<Renderer>().enabled == false)
                {
                    Key.GetComponent<Renderer>().enabled = false;
                    isPlayersInactive = true;
                    inactiveTimer = 5f; // 카운트 시작 시 타이머 초기화
                }
            }
            if(keyOwner.GetComponent<Renderer>().enabled){
                Key.GetComponent<Renderer>().enabled = true;
            }
            else{
                Key.GetComponent<Renderer>().enabled = false;
            }
            if (isPlayersInactive)
            {
                // 타이머 감소
                inactiveTimer -= Time.deltaTime;

                if (inactiveTimer <= 0f)
                {
                    // 5초가 끝나면 씬 이동
                    SceneManager.LoadScene(sceneName);
                }
            }
        }

    }

}
