using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    private NetworkVariable<Vector3> _position = new NetworkVariable<Vector3>();
    private NetworkVariable<SpriteRenderer> _spriteRenderer = new NetworkVariable<SpriteRenderer>();

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    public override void OnNetworkSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }

        // Jump        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

        float moveX = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
        }

        // move
        // Vector3 move = new Vector3(moveX, 0, 0);
        transform.position += _position.Value * moveSpeed * Time.deltaTime;

        // flip
        if (moveX < 0)
        {
            _spriteRenderer.Value.flipX = false;
        }
        else if (moveX > 0)
        {
            _spriteRenderer.Value.flipX = true;
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
        }

    }

    [ServerRpc]
    private void TestServerRpc()
    {
        Debug.Log("TestServerRpc");
    }

    [ClientRpc]
    private void TestClientRpc()
    {
        Debug.Log("TestClientRpc");
    }
}
