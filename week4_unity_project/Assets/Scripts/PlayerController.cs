using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    public NetworkVariable<Vector3> position = new NetworkVariable<Vector3>();
    public NetworkVariable<Color> playerColor = new NetworkVariable<Color>();

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    
    public Transform groundCheck;
    public LayerMask groundLayer;


    Rigidbody2D m_Rigidbody2D;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;
    [SerializeField] SpriteRenderer m_SpriteRenderer;
    Animator m_Animator;
    private Renderer objectRenderer;
    public float doorDistance = 1f;

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Animator = GetComponent<Animator>();
        objectRenderer = m_Rigidbody2D.GetComponent<Renderer>();
    }

    public override void OnNetworkSpawn()
    {
        if (IsServer) 
        {

        }

    }

    private void Update()
    {
        if (IsServer)
        {
            UpdateServer();
        }

        if (IsClient)
        {
            UpdateClient();
        }

    }

    void UpdateServer()
    {
        // update position
        position.Value = transform.position;

        // update direction
        if (m_SpriteRenderer.flipX)
        {
            FlipSpriteClientRpc(true);
        }
        else
        {
            FlipSpriteClientRpc(false);
        }
    }

    void UpdateClient()
    {
        if (!IsLocalPlayer)
        {
            return;
        }

        float moveX = 0f;

        if (objectRenderer.enabled&&Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        else if (objectRenderer.enabled&&Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
        }

        // move
        Vector3 move = new Vector3(moveX, 0, 0);
        transform.position += move * moveSpeed * Time.deltaTime;

        // flip
        if (moveX < 0)
        {   
            m_SpriteRenderer.flipX = false;
            FlipSpriteServerRpc(false);
        }
        else if (moveX > 0)
        {
            m_SpriteRenderer.flipX = true;
            FlipSpriteServerRpc(true);
        }

        if (Mathf.Abs(moveX) < 0.3)
        {
            m_Animator.SetBool("isWalking", false);
        }
        else
        {
            m_Animator.SetBool("isWalking", true);
        }

        // Debug.DrawRay(rb.position, Vector3.down, new Color(255, 0, 0));

        if (m_Rigidbody2D.velocity.y < 0)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(m_Rigidbody2D.position, Vector3.down, 1, LayerMask.GetMask("floor"));
            RaycastHit2D rayHit2 = Physics2D.Raycast(m_Rigidbody2D.position, Vector3.down, 1, LayerMask.GetMask("pinkPlayer"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                    m_Animator.SetBool("isJumping", false);
            }
            else if (rayHit2.collider != null)
            {
                if (rayHit2.distance < 0.5f)
                    m_Animator.SetBool("isJumping", false);
            }
        }

        // Jump        
        if (isGrounded&&objectRenderer.enabled&&Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            m_Animator.SetBool("isJumping", true);
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

    // flip sync
    [ClientRpc]
    private void FlipSpriteClientRpc(bool flip)
    {
        if (IsLocalPlayer)
        {
            return;
        }

        m_SpriteRenderer.flipX = flip;
    }

    // flip sync
    [ServerRpc]
    private void FlipSpriteServerRpc(bool flip)
    {
        if (!IsLocalPlayer)
        {
            return;
        }

        m_SpriteRenderer.flipX = flip;
    }
}
