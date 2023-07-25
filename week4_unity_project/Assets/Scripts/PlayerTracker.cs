using UnityEngine;

public class MonsterChasePlayer : MonoBehaviour
{
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
        if (player.GetComponent<Rigidbody2D>().velocity.magnitude > maxPlayerSpeed)
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

        
    }
}
