using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBlock : MonoBehaviour
{
    BoxCollider2D boxCollider;
    private Renderer objectRenderer;
    bool playerOn = false;
    bool startTimer = false;
    bool reCreate = false;
    private float inactiveTimer = 2f;

    public float fadeSpeed = 0.5f; // 투명도 조정 속도

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float currentAlpha = 1f;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        objectRenderer = GetComponent<Renderer>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 초기 색상 기억
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerOn)
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.up, 1, LayerMask.GetMask("bluePlayer", "pinkPlayer"));
            if (raycastHit.collider != null)
            {
                playerOn = true;
            }
        }

    }

    void FixedUpdate()
    {
        if ((!startTimer) && playerOn)
        {
            inactiveTimer = 1.5f;
            startTimer = true;
        }
        if (startTimer&&(!reCreate))
        {
            currentAlpha -= fadeSpeed * Time.deltaTime; // 투명도를 감소시킴

            // 알파 값이 0 미만이면 완전히 투명한 상태로 설정
            if (currentAlpha < 0f)
            {
                currentAlpha = 0f;
            }

            // 스프라이트의 색상을 현재 알파 값으로 변경
            Color newColor = originalColor;
            newColor.a = currentAlpha;
            spriteRenderer.color = newColor;
            inactiveTimer -= Time.deltaTime;
            if (inactiveTimer <= 0f)
            {
                objectRenderer.enabled = false;
                boxCollider.enabled = false;
                inactiveTimer = 1.5f;
                reCreate = true;
            }
        }
        else if(reCreate){
            currentAlpha = 1f;
            Color newColor = originalColor;
            newColor.a = currentAlpha;
            spriteRenderer.color = newColor;

            inactiveTimer -= Time.deltaTime;
            if(inactiveTimer <=0f){
                objectRenderer.enabled = true;
                boxCollider.enabled = true;
                reCreate = false;
                playerOn = false;
                startTimer = false;
            }
        }
    }
}
