using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueMove : MonoBehaviour
{
    public GameObject nupjukBlue;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    private Renderer objectRenderer;
    private Collider2D myCollider;
    public bool isMovingBlock = false;
    public GameObject blockObject;

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

    public bool onElevator = false;
    public float minY;
    public float maxY;

    [SerializeField]
    private float moveSpeed = 5f;
    private float jumpForce = 5f;
    private float doorDistance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        objectRenderer = rb.GetComponent<Renderer>();
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
        if (((!isJumping) && objectRenderer.enabled) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, doorDistance, LayerMask.GetMask("floor"));
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector3.left, doorDistance, LayerMask.GetMask("floor"));

        if (Input.GetKeyDown(KeyCode.DownArrow))
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
                else
                {
                    movingUp = false;
                }
            }
            else
            {
                gg_moveSpeed = 1f;
                if (Vector3.Distance(transform.position, startPos) > 0.1f)
                {
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

        RaycastHit2D elevatorHit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("floor"));
        if((elevatorHit.collider!=null)&& elevatorHit.collider.CompareTag("Elevator")){
            onElevator = true;
        }
        else{
            onElevator = false;
        }

    }

    void FixedUpdate()
    {
        float moveX = 0f;
        isMovingBlock = false;
        if (objectRenderer.enabled && Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
            RaycastHit2D blockHit = Physics2D.Raycast(rb.position, Vector2.left, (float)0.6, LayerMask.GetMask("block"));
            if (blockHit.collider != null)
            {
                isMovingBlock = true;
                blockObject = blockHit.collider.gameObject;
            }

        }
        else if (objectRenderer.enabled && Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
            RaycastHit2D blockHit = Physics2D.Raycast(rb.position, Vector2.right, (float)0.6, LayerMask.GetMask("block"));
            if (blockHit.collider != null)
            {
                isMovingBlock = true;
                blockObject = blockHit.collider.gameObject;
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

        // Debug.DrawRay(rb.position, Vector3.down, new Color(255, 0, 0));

        if (rb.velocity.y <= 0)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 1, LayerMask.GetMask("floor", "pinkPlayer", "block"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1f)
                    anim.SetBool("isJumping", false);
            }
        }
        if(transform.position.y<minY){
            cameraFollow.SetCameraMoveEnabled(false);
            transform.Translate(-3f, 15f, 0f);
        }else if(transform.position.y>maxY){
            cameraFollow.SetCameraMoveEnabled(false);
        }
        else{
            cameraFollow.SetCameraMoveEnabled(true);
        }
    }
}
