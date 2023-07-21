using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkMove : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    [SerializeField]
    private float moveSpeed = 5f;
    private float jumpForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // rb.gravityScale = 1f;
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        // Jump        
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

    }

    void FixedUpdate()
    {
        float moveX = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
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

        if (rb.velocity.y < 0)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 1, LayerMask.GetMask("floor"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                    anim.SetBool("isJumping", false);
            }
            // }
            // if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            // {
            //     // 아무런 동작을 취하지 않습니다.
            //     // 또는 원하는 처리를 수행할 수도 있습니다.
        }
    }
}
