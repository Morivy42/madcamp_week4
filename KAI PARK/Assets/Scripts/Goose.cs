using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DontWakeGoose : MonoBehaviour
{
    
    // 키보드 입력 횟수를 저장할 변수
    int keyCount = 0;
    // maxKeyCount 를 저장할 변수 // 125
    int maxKeyCount = 0;

    Animator animator;
    private bool isChasing = false;
    private bool isSleeping = true;

    bool gooseHit = false;
    bool blueHit = false;
    bool pinkHit = false;
    public GameObject nupjukPink;
    public GameObject nupjukBlue;
    public Transform player;
    public float chaseSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ResetKeyCount", 0.3f, 1f);
        InvokeRepeating("GetMaxKeyCount", 0.3f, 1f);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetKeyCount();

        if (keyCount > 50) 
        {
            isSleeping = false;
            animator.SetBool("isSleeping", false);
            if (keyCount > 200)
            {
                isChasing = true;
            }
        } 
        else 
        {
            isSleeping = true;
            animator.SetBool("isSleeping", true);
        }

        

        // 추적 상태라면
        if (isChasing)
        {
            // 플레이어를 향해 이동한다.
            transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
            animator.SetBool("isChasing", true);

            if (!gooseHit)
            {
                RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.right, 2f, LayerMask.GetMask("bluePlayer", "pinkPlayer"));
                if (raycastHit.collider != null)
                {
                    gooseHit = true;
                    //layer 6: bluePlayer, 7: pinkPlayer
                    if (raycastHit.collider.gameObject.layer == 6)
                    {
                        blueHit = true;
                    }
                    else if (raycastHit.collider.gameObject.layer == 7)
                    {
                        pinkHit = true;
                    }
                }
            }

            if (pinkHit)
            {
                nupjukPink.GetComponent<PinkMove>().isAlive =false;
                pinkHit = false;
                // pinkSpriteRenderer.sprite = newPinkSprite;
                
            }
            if (blueHit)
            {
                nupjukBlue.GetComponent<BlueMove>().isAlive =false;
                blueHit = false;
            }
        }

        
    }

    // 키보드 입력 횟수를 반환하는 함수
    int GetKeyCount()
    {        
        // 키입력을 감지하는 함수
        if(Input.GetKey(KeyCode.W))
            keyCount++;
        if(Input.GetKey(KeyCode.A))
            keyCount++;
        if(Input.GetKey(KeyCode.S))
            keyCount++;
        if(Input.GetKey(KeyCode.D))
            keyCount++;
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            keyCount++;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            keyCount++;
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            keyCount++;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            keyCount++;
        }

        // Debug.Log(keyCount);
        if(keyCount > maxKeyCount)
        {
            maxKeyCount = keyCount;
        }

        // 키보드 입력 횟수를 반환
        return keyCount;
    }

    void ResetKeyCount()
    {
        keyCount = 0;
    }

    // keyCount 의 최대값을 반환하는 함수
    int GetMaxKeyCount()
    {
        Debug.Log(maxKeyCount);
        return maxKeyCount;
    }
}
