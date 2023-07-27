using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectEnable : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private bool isClear = false;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        // 클리어 되었는지 확인
        isClear = PlayerPrefs.GetString(sceneName) == "cleared";
        if (!isClear)
        {
            // spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            foreach (Transform child in transform)
            {
                if (child.name == "Button")
                {
                    child.gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    // 자식 중에 버튼을 찾아서 비활성화
    private void Awake()
    {
                // 클리어 되지 않았다면 반투명으로 설정
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}