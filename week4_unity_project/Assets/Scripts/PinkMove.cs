using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinkMove : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    public GameObject nupjukPink;
    public GameObject nupjukBlue;
    private Renderer objectRenderer;
    private Collider2D myCollider;
    public bool isMovingBlock = false;

    public bool isAlive = true;
    public Sprite gameoverSprite;
    private float inactiveTimer = 1f;
    private float gg_moveSpeed = 14f;
    private float distance = 4f;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingUp = true;
    public CameraFollow cameraFollow;
    private bool animStart = false;

    [SerializeField]
    private float moveSpeed = 5f;
    private float jumpForce = 5f;
    private float doorDistance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // rb.gravityScale = 1f;
        objectRenderer = GetComponent<Renderer>();
        myCollider = GetComponent<Collider2D>();
        inactiveTimer = 1f;
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumping = anim.GetBool("isJumping");
        // Jump        
        if (((!isJumping) && objectRenderer.enabled) && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, doorDistance, LayerMask.GetMask("floor"));
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector3.left, doorDistance, LayerMask.GetMask("floor"));

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (objectRenderer.enabled == false)
            {
                objectRenderer.enabled = true;
            }
            else if (hit.collider != null && hit.collider.CompareTag("Door"))
            {
                if (hit.distance < 1f)
                {
                    objectRenderer.enabled = false;
                }
            }
            else if (hit2.collider != null && hit2.collider.CompareTag("Door"))
            {
                if (hit2.distance < 1f)
                {
                    objectRenderer.enabled = false;
                }
            }
        }

        //game over 시 처리
        if (!isAlive)
        {
            anim.enabled = false;
            sr.sprite = gameoverSprite;
            inactiveTimer -= Time.deltaTime;

            if (inactiveTimer <= 0f)
            {
                animStart = true;
                startPos = transform.position;
                endPos = startPos + Vector3.up * distance;
                isAlive = true;
            }
        }
        
            
        if (animStart)
        {
            myCollider.isTrigger = true;
            cameraFollow.SetCameraMoveEnabled(false);
            if (movingUp)
            {
                gg_moveSpeed = 11f;
                if (Vector3.Distance(transform.position, endPos) > 0.3f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, endPos, gg_moveSpeed * Time.deltaTime);
                }   
                else{
                    movingUp = false;
                }
            }
            else
            {
                gg_moveSpeed = 1f;
                if (Vector3.Distance(transform.position, startPos) > 0.1f){
                    transform.position = Vector3.MoveTowards(transform.position, startPos, gg_moveSpeed * Time.deltaTime);
                }
                else
                {
                    animStart = false;
                    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                    SceneManager.LoadScene(currentSceneIndex);
                }
            }
        }


    }

    void FixedUpdate()
    {
        float moveX = 0f;

        isMovingBlock = false;
        if (objectRenderer.enabled && Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            RaycastHit2D blockHit = Physics2D.Raycast(rb.position, Vector2.left, (float)0.6, LayerMask.GetMask("block"));
            if (blockHit.collider != null)
            {
                isMovingBlock = true;
            }
        }
        else if (objectRenderer.enabled && Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
            RaycastHit2D blockHit = Physics2D.Raycast(rb.position, Vector2.right, (float)0.6, LayerMask.GetMask("block"));
            if (blockHit.collider != null)
            {
                isMovingBlock = true;
            }
        }
        // move
        Vector3 move = new Vector3(moveX, 0, 0);
        transform.position += move * moveSpeed * Time.deltaTime;

        // flip
        if (moveX < 0)
        {
            sr.flipX = false;
        }
        else if (moveX > 0)
        {
            sr.flipX = true;
        }

        if (Mathf.Abs(moveX) < 0.3)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }

        // Debug.DrawRay(rb.position, Vector3.down, new Color(0, 0, 0));

        if (rb.velocity.y <= 0)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 1, LayerMask.GetMask("floor", "bluePlayer", "block"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1f)
                    anim.SetBool("isJumping", false);
            }
        }
        if(transform.position.y<-4.5f){
            transform.Translate(0f, 15f, 0f);
        }
    }


}
