using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raser : MonoBehaviour
{
    bool raserHit = false;
    bool gameOver = false;
    bool animStart = false;
    bool blueHit = false;
    bool pinkHit = false;
    public GameObject nupjukPink;
    public GameObject nupjukBlue;
    public Sprite newPinkSprite;
    public Sprite newBlueSprite;
    private SpriteRenderer pinkSpriteRenderer;
    private SpriteRenderer blueSpriteRenderer;
    private Animator pinkAnimator;
    private Animator blueAnimator;

    public CameraFollow cameraFollow;

    private float inactiveTimer = 1f;

    private float moveSpeed = 10f;
    private float distance = 4f;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        blueSpriteRenderer = nupjukBlue.GetComponent<SpriteRenderer>();
        pinkSpriteRenderer = nupjukPink.GetComponent<SpriteRenderer>();
        pinkAnimator = nupjukPink.GetComponent<Animator>();
        blueAnimator = nupjukBlue.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!raserHit)
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.up, (float)0.2, LayerMask.GetMask("bluePlayer", "pinkPlayer"));
            if (raycastHit.collider != null)
            {
                raserHit = true;
                //layer 6: bluePlayer, 7: pinkPlayer
                if (raycastHit.collider.gameObject.layer == 6)
                {
                    blueHit = true;
                    blueAnimator.enabled = false;
                }
                else if (raycastHit.collider.gameObject.layer == 7)
                {
                    pinkHit = true;
                    pinkAnimator.enabled = false;
                }
            }
        }

        if (pinkHit)
        {
            pinkSpriteRenderer.sprite = newPinkSprite;
        }
        if (blueHit)
        {
            blueSpriteRenderer.sprite = newBlueSprite;
        }
        
    }

    void FixedUpdate()
    {
        if (raserHit && (!gameOver))
        {
            gameOver = true;
            inactiveTimer = 1f;
        }
        if (gameOver)
        {
            inactiveTimer -= Time.deltaTime;

            if (inactiveTimer <= 0f)
            {
                animStart = true;
                startPos = nupjukBlue.transform.position;
                endPos = startPos + Vector3.up * distance;
                gameOver = false;
            }
        }
        if (animStart)
        {
            cameraFollow.SetCameraMoveEnabled(false);
            if (movingUp)
            {
                moveSpeed = 13f;
                if (Vector3.Distance(nupjukBlue.transform.position, endPos) > 0.3f)
                {
                    nupjukBlue.transform.position = Vector3.MoveTowards(nupjukBlue.transform.position, endPos, moveSpeed * Time.deltaTime);
                }   
                else{
                    movingUp = false;
                }
            }
            else
            {
                moveSpeed = 4f;
                if (Vector3.Distance(nupjukBlue.transform.position, startPos) > 0){
                    nupjukBlue.transform.position = Vector3.MoveTowards(nupjukBlue.transform.position, startPos, moveSpeed * Time.deltaTime);
                }
                else
                {
                    animStart = false;
                    SceneManager.LoadScene("Map1");
                }
            }
        }

    }
}
