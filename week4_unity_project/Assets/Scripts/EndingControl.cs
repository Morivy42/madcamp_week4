using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingControl : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerPrefs.SetString("theEnd", "true");
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 애니메이션이 끝났는지 확인합니다.
        if (stateInfo.normalizedTime >= 0.99f)
        {
            SceneManager.LoadScene("OpeningScene");
        }
    }
}
