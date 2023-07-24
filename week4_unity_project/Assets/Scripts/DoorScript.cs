using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameObject nupjukBlue;
    public GameObject nupjukPink;
    private Renderer blueRenderer;
    private Renderer pinkRenderer;
    private bool isPlayersInactive = false;
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
        if (pinkRenderer.enabled == false && blueRenderer.enabled == false)
        {
            isPlayersInactive = false;
            SceneManager.LoadScene("SampleScene");
        }

        if (isPlayersInactive==false && (pinkRenderer.enabled != blueRenderer.enabled))
        {
            isPlayersInactive = true;
            inactiveTimer = 5f; // 카운트 시작 시 타이머 초기화
        }
        if (isPlayersInactive)
        {
            // 타이머 감소
            inactiveTimer -= Time.deltaTime;

            if (inactiveTimer <= 0f)
            {
                // 5초가 끝나면 씬 이동
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

}