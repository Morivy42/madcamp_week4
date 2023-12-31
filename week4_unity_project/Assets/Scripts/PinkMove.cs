using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    public TMP_Text message;

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
        if(!nupjukBlue.GetComponent<BlueMove>().isAlive){
            isAlive = false;
        }
        bool isJumping = anim.GetBool("isJumping");
        // Jump        
        if (((!isJumping) && objectRenderer.enabled) && Input.GetKeyDown(KeyCode.W)&&isAlive)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, doorDistance, LayerMask.GetMask("floor"));
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector3.left, doorDistance, LayerMask.GetMask("floor"));

        if (Input.GetKeyDown(KeyCode.S)&&isAlive)
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
        if ((!isAlive) && (!animStart))
        {
            anim.enabled = false;
            sr.sprite = gameoverSprite;
            inactiveTimer -= Time.deltaTime;

            if (inactiveTimer <= 0f)
            {
                animStart = true;
                startPos = transform.position;
                endPos = startPos + Vector3.up * distance;
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
                Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.position);
                Vector3 minPosition = new Vector3(startPos.x, viewPosition.y, startPos.z);
                if (Vector3.Distance(transform.position, minPosition) > 0.1f)
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
        if ((elevatorHit.collider != null) && elevatorHit.collider.CompareTag("Elevator"))
        {
            onElevator = true;
        }
        else
        {
            onElevator = false;
        }


    }

    void FixedUpdate()
    {
        float moveX = 0f;

        isMovingBlock = false;
        if (objectRenderer.enabled && Input.GetKey(KeyCode.A) && isAlive)
        {
            moveX = -1f;
            RaycastHit2D blockHit = Physics2D.Raycast(rb.position, Vector2.left, (float)0.6, LayerMask.GetMask("block"));
            if (blockHit.collider != null)
            {
                isMovingBlock = true;
                blockObject = blockHit.collider.gameObject;
            }
        }
        else if (objectRenderer.enabled && Input.GetKey(KeyCode.D) && isAlive)
        {
            moveX = 1f;
            RaycastHit2D blockHit = Physics2D.Raycast(rb.position, Vector2.right, (float)0.6, LayerMask.GetMask("block"));
            if (blockHit.collider != null)
            {
                isMovingBlock = true;
                blockObject = blockHit.collider.gameObject;
            }
        }
        if (isAlive)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                message.text = "Go!";
            }
            else if (Input.GetKey(KeyCode.E))
            {
                message.text = "Stop!";
            }
            else if (Input.GetKey(KeyCode.F))
            {
                message.text = "Jump!";
            }
            else
            {
                message.text = "";
            }
        }
        // move
        Vector3 move = new Vector3(moveX, 0, 0);
        transform.position += move * moveSpeed * Time.deltaTime;
        //카메라를 벗어나지 않도록 범위 제한
        Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.position);
        viewPosition.x = Mathf.Clamp(viewPosition.x, 0.1f, 0.9f);
        // viewPosition.y = Mathf.Clamp(viewPosition.y, 0.1f, 0.9f);
        Vector3 pos = Camera.main.ViewportToWorldPoint(viewPosition);
        transform.position = pos;

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

        // 화면 최대 최소 값 좌표 구하기
        Vector3 minWorldPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxWorldPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        if (transform.position.y < minWorldPos.y)
        {
            // transform.Translate(-3f, 15f, 0f);
            transform.position = new Vector3(transform.position.x, maxWorldPos.y, transform.position.z);
        }
    }


}
