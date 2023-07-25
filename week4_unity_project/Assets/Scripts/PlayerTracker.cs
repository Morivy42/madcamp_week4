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
        // 플레이어와 몬스터 사이의 거리를 계산합니다.
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 플레이어의 평균 속도가 설정한 최대 속도를 넘을 경우 플레이어를 추적합니다.
        if (player.GetComponent<Rigidbody2D>().velocity.magnitude > maxPlayerSpeed)
        {
            isChasing = true;
            anim.SetBool("isChasing", true);

            // 플레이어의 위치를 향해 방향을 계산합니다.
            Vector3 direction = (player.position - transform.position).normalized;

            // 몬스터가 플레이어를 추적하도록 이동합니다.
            transform.position += direction * chaseSpeed * Time.deltaTime;
        } 
        else
        {
            isChasing = false;
            anim.SetBool("isChasing", false);

        }
    }
}
