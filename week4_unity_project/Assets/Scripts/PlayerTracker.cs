using UnityEngine;

public class GooseChase : MonoBehaviour
{
    bool gooseHit = false;
    bool blueHit = false;
    bool pinkHit = false;
    public GameObject nupjukPink;
    public GameObject nupjukBlue;
    public Transform player;
    public float chaseSpeed = 5f;
    public float maxPlayerSpeed = 3f;
    private bool isChasing = false;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // 플레이어의 속도가 maxPlayerSpeed보다 크면
        if (nupjukBlue.GetComponent<Rigidbody2D>().velocity.magnitude > maxPlayerSpeed)
        {
            // 추적을 시작한다.
            isChasing = true;
        }

        // 추적 상태라면
        if (isChasing)
        {
            // 플레이어를 향해 이동한다.
            transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
            anim.SetBool("isChasing", true);
        }
        else
        {
            anim.SetBool("isChasing", false);
        }


        if (!gooseHit)
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.up, 10f, LayerMask.GetMask("bluePlayer", "pinkPlayer"));
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
            // nupjukPink.GetComponent<PinkMove>().isAlive =false;
            pinkHit = false;
            isChasing = false;
            // pinkSpriteRenderer.sprite = newPinkSprite;
            
        }
        if (blueHit)
        {
            // nupjukBlue.GetComponent<BlueMove>().isAlive =false;
            blueHit = false;
            isChasing = false;

        }
        
    }
}
